#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<time.h>
#include<limits.h>
const char *file_names[10]={"Datasets/test1.txt", "Datasets/test2.txt", "Datasets/test3.txt", "Datasets/test4.txt", "Datasets/test5.txt", "Datasets/test6.txt", "Datasets/test7.txt", "Datasets/test8.txt", "Datasets/test9.txt", "Datasets/test10.txt"};
int *value;
int *weight;
int bag_size;
int bag_limit;
int colony_size=60;
int limit;
int *limitArray;
int global_bFitness;
int global_bIndex;
int iteration=100;

int fitness(int *cur_knap)
{
    int i,sum=0;
    for(i=0;i<bag_size;i++)
    {
        if(cur_knap[i])sum+=value[i];
    }
    return sum;
}


int calcWeight(int *cur_knap)
{
    int i,sum=0;
    for(i=0;i<bag_size;i++)
    {
        if(cur_knap[i])sum+=weight[i];
    }
    return sum;
}


int printBag(int **a)
{
    int i,j;
    printf("\n");

    for(i=0;i<colony_size;i++)
    {
        for(j=0;j<bag_size;j++)
        {
            printf("%d ",a[i][j]);
        }
        printf(" -> %d\n",fitness(a[i]));
    }
    printf("\n");
}


void readFile(int i)
{
    FILE * fp = fopen(file_names[i],"r");
    int counter=0,temp;
    char c;
    fscanf(fp,"%d",&temp);
    while(!feof(fp))
    {
        fscanf(fp,"%d",&temp);
        counter++;
    }
    fseek(fp, 0, SEEK_SET);
    bag_size = counter/2;
    weight = calloc(bag_size,sizeof(int));
    value = calloc(bag_size,sizeof(int));
    counter = 0;
    fscanf(fp,"%d",&bag_limit);
    while(!feof(fp))
    {
        fscanf(fp,"%d",&temp);
        if(counter<bag_size)
        {
            weight[counter]=temp;
        }
        else
        {
            value[(counter-bag_size)]=temp;
        }

        counter++;
    }
    fclose(fp);
}


typedef struct greedy
{
    double rate;
    int index;
}greedyIndex;


int compare(const void * a, const void * b)
{
    const greedyIndex *first=(greedyIndex *)a;
    const greedyIndex *second=(greedyIndex *)b;
    return (first->rate < second->rate)-(first->rate > second->rate);
}


int *generateGreedySolution()
{
    greedyIndex *rates = calloc(bag_size, sizeof(greedyIndex));
    int i;
    for(i=0;i<bag_size;i++)
    {
        rates[i].index=i;
        rates[i].rate=value[i]/(double)weight[i];
    }

    qsort(rates,bag_size,sizeof(greedyIndex),compare);

    int *result = calloc(bag_size, sizeof(int));
    int sum_weight=0;

    for(i=0;i<bag_size;i++)
    {
        if(sum_weight+weight[rates[i].index]<=bag_limit)
        {
            sum_weight+=weight[rates[i].index];
            result[rates[i].index]=1;
        }
        else break;
    }
    return result;
}


int rouletteSelection(int **solutions)
{
    //srand(time(NULL));
    int i,sum=0;
    double *normalized=calloc(colony_size,sizeof(double));
    for(i=0;i<colony_size;i++)
    {
        sum+=fitness(solutions[i]);
    }

    for(i=0;i<colony_size;i++)
    {
        normalized[i]=fitness(solutions[i])/(double)sum;
    }

    sum=0;
    double P=rand()/(RAND_MAX + 1.);
   
    for(i=0;i<colony_size;i++)
    {
        if(P<=sum)return i;
        else
        {
            sum+=normalized[i];
        }
    }
	return i-1;
}


double similarity(int *a, int *b)
{
	int i;
	int M_11=0,M_01=0,M_10=0;
	
	for(i=0;i<bag_size;i++)
	{
		if(a[i]==1 && b[i]==1)M_11++;
		else if(a[i]==0 && b[i]==1)M_01++;
		else if(a[i]==1 && b[i]==0)M_10++;
	}
	return M_11/(double)(M_01+M_10+M_11);
}


void getRandomSolution(int *result, int **solutions,int i)
{
    //srand(time(NULL));
    double fi = rand()/(RAND_MAX + 1.);
    int t,temp=0,n0=0,n1=0,M_11,M_10,M_01,FINAL_M_11,FINAL_M_10,FINAL_M_01;
    for(t=0;t<bag_size;t++)
    {
    	if(solutions[i][t])n1++;
    	else n0++;
	}
	int k;
	do
	{
		k = (rand()%colony_size);
	}while(k==i);
    
    
	double ROS=fi*(1-similarity(solutions[i],solutions[k]));
	double minz=INT_MAX;
	for(M_11=0;M_11<=n1;M_11++)
	{
		for(M_01=0;M_01<=n1;M_01++)
		{
			for(M_10=0;M_10<=n0;M_10++)
			{
				if(M_11+M_01==n1)
				{
					if(fabs(1-(M_11/(double)(M_11+M_10+M_01))-ROS)<minz)
					{
						minz=fabs(1-(M_11/(double)(M_11+M_10+M_01))-ROS);
						FINAL_M_01=M_01;
						FINAL_M_10=M_10;
						FINAL_M_11=M_11;
					}
				}
			}
		}
	}
	int * indexesofone=calloc(n1,sizeof(int));
	int * indexesofzero=calloc(n0,sizeof(int));
	int i_k=0,i_l=0;
	for(t=0;t<bag_size;t++)
    {
    	if(solutions[i][t])
    	{
    		indexesofone[i_k]=t;
    		i_k++;
		}
    	else
    	{
    		indexesofzero[i_l]=t;
    		i_l++;
		}
	}
	
	int idx;
	for(t=0;t<FINAL_M_11;t++)
	{
		idx=indexesofone[rand()%n1];
		result[idx]=1;
	}
	for(t=0;t<FINAL_M_10;t++)
	{
		idx=indexesofzero[rand()%n0];
		result[idx]=1;
	}
	
	while(calcWeight(result)>bag_limit)
    {
    	result[rand()%bag_size]=0;
	}
	/*for(t=0;t<bag_size;t++)
	{
		printf("%d ",result[t]);
	}*/
	printf("%d\n",fitness(result));
	//printf("%d %d %d",FINAL_M_11,FINAL_M_01,FINAL_M_10);  
}


void initializeKnapsack(int **solutions)
{
    int i, j;
    double random_number;
    //srand(time(NULL));
    for(i=0;i<colony_size;i++)
    {
        for(j=0;j<bag_size;j++)
        {
        	random_number = rand()/(double)(RAND_MAX);
        	if(random_number<0.5)solutions[i][j]=0;
        	else solutions[i][j]=1;
        }
        while(calcWeight(solutions[i])>bag_limit)
        {
        	solutions[i][rand()%bag_size]=0;
		}
    }
    solutions[rand()%colony_size]=generateGreedySolution();
}


void employeeBeePhase(int **solutions)
{
    int i;
    for(i=0;i<colony_size;i++)
    {
        int j;
        int *result = calloc(bag_size, sizeof(int));
        
        getRandomSolution(result, solutions,i);

        if(fitness(result)>fitness(solutions[i]))
        {
        	//printf("employeeBeePhase--seçildi\n");
            for(j=0;j<bag_size;j++)
            {
                solutions[i][j]=result[j];
            }
            limitArray[i]=0;
        }
    }
}


void onlookerBeePhase(int **solutions)
{
    int i;
    for(i=0;i<colony_size;i++)
    {
        int index = rouletteSelection(solutions);
        int j;
        int *result = calloc(bag_size, sizeof(int));

        getRandomSolution(result, solutions, index);

        if(fitness(result)>fitness(solutions[index]))
        {
        	//printf("onlookerBeePhase--seçildi\n");
            for(j=0;j<bag_size;j++)
            {
                solutions[index][j]=result[j];
            }
            limitArray[index]=0;
        }
    }

}


void searchColonyForWeakOne(int **solutions)
{
	//srand(time(NULL));
    int i,j;
    for(i=0;i<colony_size;i++)
    {
        if(limitArray[i]>=limit)
        {      
        	double random_number;
            for(j=0;j<bag_size;j++)
            {
                random_number = rand()/(double)(RAND_MAX);
	        	if(random_number<0.5)solutions[i][j]=0;
	        	else solutions[i][j]=1;
            }
            while(calcWeight(solutions[i])>bag_limit)
          	{
           		solutions[i][rand()%bag_size]=0;
   			}
            limitArray[i]=0;
            break;
        }
    }
}


void colonyAging()
{
    int i;
    for(i=0;i<colony_size;i++)
    {
        limitArray[i]++;
    }
}


void printColonyAges()
{
	int i;
	for(i=0;i<colony_size;i++)
    {
        printf("%d ",limitArray[i]);
    }
    printf("\n");
}


void findGlobalBest(int **solutions)
{
    int i;
    for(i=0;i<colony_size;i++)
    {
        if(fitness(solutions[i])>global_bFitness)
        {
            global_bFitness=fitness(solutions[i]);
            global_bIndex=i;
        }
    }
}


double p_local=1;
int n_local;
void localSearch(int **solutions)
{
	 n_local=sqrt(colony_size);
	 double rnd = rand()/(double)(RAND_MAX+1.);
	 int i,j;
	 if(rnd<p_local)
	 {
	 	for(i=0;i<n_local;i++)
	 	{
	 		int *result = calloc(bag_size,sizeof(int));
	 		for(j=0;j<bag_size;j++)
			{
			 	result[j]=!solutions[i][j];
			}
			if(fitness(result)>fitness(solutions[i]))
			{
				while(calcWeight(result)>bag_limit)
			    {
			    	result[rand()%bag_size]=0;
				}
			 	for(j=0;j<bag_size;j++)
				{
				 	solutions[i][j]=result[j];
				}
			}	
		}
	 }
}


int main()
{
    int i,j;
    limit=colony_size/2;
    for(i=0;i<1;i++)
    {
        readFile(i);
        int ** solutions = calloc(colony_size,sizeof(int*));
        for(j=0;j<colony_size;j++)
        {
            solutions[j]=calloc(bag_size,sizeof(int));
        }
        initializeKnapsack(solutions);
        findGlobalBest(solutions);
        limitArray=calloc(colony_size,sizeof(int));
        for(j=0;j<iteration;j++)
        {
            employeeBeePhase(solutions);
            onlookerBeePhase(solutions);
            findGlobalBest(solutions);
            localSearch(solutions);
            searchColonyForWeakOne(solutions);  
			colonyAging();					
			//printBag(solutions);
			//printColonyAges();
        }
        printf("%d %d\n",global_bFitness,fitness(generateGreedySolution()));
        global_bFitness=0;
    }
    
}
