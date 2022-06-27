using System;
using static System.Math;
using static System.Console;

/*list.data is an array of 'T', where T is the type. 
Thus if the type is array, we would get an array of arrays 
- a so-called 'jagged array'
*/
public class genlist<T>{
    public T[] data; 
    
    public int size => data.Length;
    
    public genlist(){data = new T[0]; } //constructor
	public void add(T item){ //push method appends an entry to the list. Entries can be arrays. 
        T[] newdata = new T[size + 1];
        for(int i=0;i<size;i++)newdata[i]=data[i];
        data=newdata;
        data[size-1] = item;
	}

}