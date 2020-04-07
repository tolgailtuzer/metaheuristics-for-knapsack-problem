#include <stdio.h> 
#include <stdlib.h> 
#include <math.h> 
#include <time.h> 
const char *file_names[10]={"Datasets/test1.txt", "Datasets/test2.txt", "Datasets/test3.txt", "Datasets/test4.txt", "Datasets/test5.txt", "Datasets/test6.txt", "Datasets/test7.txt", "Datasets/test8.txt", "Datasets/test9.txt", "Datasets/test10.txt"}; 
const char *file_write[10]={"test1_5_results.txt", "test2_5_results.txt", "test3_5_results.txt", "test4_5_results.txt", "test5_5_results.txt", "test6_5_results.txt", "test7_5_results.txt", "test8_5_results.txt", "test9_5_results.txt", "test10_5_results.txt"}; 

//punishment threshold weight 
int bestW; 
int bestV; 
int *maxIndex; 
int *sumWeight; 
int *sumValue; 
int *weights; 
int *values; 
int bestie; 
// item count
int size; 
// capacity 
int limit; 
// colony member size 
int antSize; 
//wide screen 
double alpha = 0.5; 
//local min 
double beta = 0.5; 
//hurricane  
double p = 0.2; 

int iteration=500; 

inline double fastPow(double a, double b) { union { double d; int x[2]; } u = { a }; u.x[1] = (int)(b * (u.x[1] - 1072632447) + 1072632447); u.x[0] = 0; return u.d; } 

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
    size = counter/2;
    weights = calloc(size,sizeof(int)); 
    values = calloc(size,sizeof(int)); 
    counter = 0; 
    fscanf(fp,"%d",&limit); 
    while(!feof(fp)) 
    { 
        fscanf(fp,"%d",&temp); 
        if(counter<size) 
        { 
            weights[counter]=temp;
        } 
        else 
        { 
            values[(counter-size)]=temp; 
        } 
        counter++; 
    } 
    fclose(fp); 
} 

void writeFile(int m,int *best,double *times,int itr) 
{ 
    double avg,tm; 
    int opt=0,i; 
    long unsigned int sum=0; 
    for(i=0;i<itr;i++) 
    { 
        sum += best[i]; 
        if(best[i]>opt) 
        { 
            opt = best[i]; 
            tm = times[i]; 
        } 
    } 
    avg = sum/itr*1.0; 
    FILE * fp = fopen(file_write[m],"w+"); 
    fprintf(fp,"%lf %d %lf",avg,opt,tm); 
    fclose(fp); 
} 

void heuristicInfo(double *ita) 
{ 
    int i; 
    for(i=0;i<size;i++) 
    { 
        ita[i] = values[i]/pow(weights[i],2); 
    } 
} 
  
void pheromoneMatrix(double *pheromone) 
{ 
    int i; 
    for(i=0;i<size;i++) 
    { 
        pheromone[i]=1; 
    } 
} 
   
void updatePheromone(double *pheromone,int **colony) 
{ 
    int i,j; 
    double temp; 
    double *deltaPheromones = calloc(size,sizeof(double)); 
    for(i=0;i<antSize;i++) 
    { 
        temp=bestV/(double)(2*bestV-sumValue[i]); 
        for(j=0;j<=maxIndex[i];j++) 
        { 
            if(colony[i][j]) deltaPheromones[j]+=temp; 
        } 
        colony[i]=calloc(size,sizeof(int)); 
        maxIndex[i]=0; 
        sumValue[i]=0; 
        sumWeight[i]=0; 
    } 
     
    for(i=0;i<size;i++) 
    { 
        pheromone[i]=(1-p)*pheromone[i]+deltaPheromones[i]; 
    } 
    free(deltaPheromones); 
} 

int calcProb(double *ita,double *pheromone,int *knap,int index) 
{ 
    double temp,sum=0; 
    double *tempP = calloc(size,sizeof(double)); 
    int i,j; 
    for(i=0;i<size;i++) 
    { 
        if(!knap[i]) 
        {     
            tempP[i] = fastPow(pheromone[i],alpha)*fastPow(ita[i],beta); 
            sum += tempP[i]; 
        } 
    } 
     
    double random = rand()/(double)RAND_MAX; 
    double sum2=0; 
     
    for(i=0;i<size;i++) 
    { 
        if(!knap[i]) 
        { 
            sum2+=(tempP[i]/sum); 
            if(sum2>=random) 
            { 
                free(tempP); 
                return i; 
            } 
        } 
    } 
} 

int main() 
{ 
    antSize=200; 
    //m file,tryn try count 
    int m,tryn=5,cc,i; 
    int bests[tryn]; 
    double times[tryn]; 

    clock_t t;  

    sumValue=calloc(antSize,sizeof(int)); 
    sumWeight=calloc(antSize,sizeof(int)); 
    maxIndex=calloc(antSize,sizeof(int)); 

    for(m=0;m<10;m++) 
    {      
        readFile(m); 
        printf("%s\n",file_names[m]);
        int **colony=calloc(antSize,sizeof(int*)); 

        for(i=0;i<antSize;i++) 
        { 
            colony[i]=calloc(size,sizeof(int)); 
        } 
         
        double *pheromone = calloc(size,sizeof(double)); 
        double *ita = calloc(size,sizeof(double)); 
        for(cc=0;cc<tryn;cc++) 
        {          
            t = clock();  
            int i,j; 
            bestie=INT_MIN; 
            pheromoneMatrix(pheromone); 
            heuristicInfo(ita);
            for(i=0;i<iteration;i++) 
            {                                             
                //colony created and start travel each ant 
                for(j=0;j<antSize;j++) 
                { 
                    int idx=rand()%size,maxIdx=0; 
                    //travel started  
                    while(sumWeight[j]+weights[idx]<=limit) 
                    {         
                        if(idx>maxIdx)maxIdx=idx; 
                        sumWeight[j]+=weights[idx]; 
                        sumValue[j]+=values[idx]; 
                        colony[j][idx] = 1;     
                        idx = calcProb(ita,pheromone,colony[j],idx); 
                    }

                    maxIndex[j]=maxIdx; 
                    if(sumValue[j]>bestie) 
                    { 
                        bestie=sumValue[j]; 
                        bestV=sumValue[j]; 
                        bestW=sumWeight[j]; 
                    }
                } 
                updatePheromone(pheromone,colony);                
            } 
            t = clock() - t;  
            printf("Fitness:%d Elapsed Time:%lf\n",bestie,((double)t)/CLOCKS_PER_SEC); 
            bests[cc]=bestie; 
            times[cc]=t;                              
        }
        //writeFile(m,bests,times,tryn);
        free(pheromone); 

        free(ita);
    } 
} 
