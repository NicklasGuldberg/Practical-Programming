using System;
using static System.Math;
using static System.Console;

/*list.data is an array of 'T', where T is the type. 
Thus if the type is array, we would get an array of arrays 
- a so-called 'jagged array'
*/
public class genlist<T>{
    public T[] data; 
    
    private int capacity = 8;
    private int size = 0;
    public int Size {get{return size;}} //get makes the size property read-only.
    public int Capacity {get{return capacity;}}
    
    //public int size = 0, capacity= 8;
    public genlist(){data = new T[capacity]; } //constructor
	public void push(T item){ //push method appends an entry to the list. Entries can be arrays. 
		if(size == capacity){
            T[] newdata = new T[capacity*=2];
            for(int i=0;i<size;i++)newdata[i]=data[i];
            data=newdata;
        }
        data[size] = item;
        size++;
	}
    public void remove(int i){
        //For loops copies all entries except the i'th.
        //The index i use same convention as arrays (starts at 0).
        T[] newdata = new T[capacity];
        if (i>size) WriteLine($"Error: No #{i} entry in list");
        for(int j=0;j<i;j++){
            newdata[j] = data[j];
        }
        for(int j=i+1;j<size;j++){
            newdata[j-1] = data[j];
        }
        data = newdata;
        size--;
    }
}