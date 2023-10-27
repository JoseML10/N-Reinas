using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NUnit.Framework;  

namespace NReinas
{
    internal class Solucion
    {
       
       static void Main (string[] args)
       {

    
        int[] tab=new int[8];

        for(int i=0; i<tab.Length;i++)
        {
            tab[i]=-1;
        }
        ColocarReina(tab,0,0);
        
        int[,] matriz = new int[8,8];
        for(int i=0;i<matriz.GetLength(0);i++)
        {
            for(int j=0;j<matriz.GetLength(1);j++)
            {
                matriz[i,j]=-1;
            }
        } 
      
        for(int i=0;i<matriz.GetLength(0);i++)
        {
            for(int j=0;j<matriz.GetLength(1);j++)
            {
               for(int k= 0;k<tab.Length;k++)
               {
                  if(k==j&&tab[k]==i)
                  {
                    matriz[i,j]=100;
                  }
               }
            }
        } 

        for(int i=0;i<matriz.GetLength(0);i++)
        {
            for(int j=0;j<matriz.GetLength(1);j++)
            {
                Console.Write(matriz[i,j] + " " + " ");
            }
            Console.WriteLine();
        } 



       }

       public void TestColocarReina()
    {
        int[] tab = new int[4];
        ColocarReina(tab, 0, 0);
        CollectionAssert.AreEqual(new int[] { 1, 3, 0, 2 }, tab);

        int[] tab2 = new int[5];
        ColocarReina(tab2, 0, 0);
        CollectionAssert.AreEqual(new int[] { 0, 2, 4, 1, 3 }, tab2);

        int[] tab3 = new int[8];
        ColocarReina(tab3, 0, 0);
        CollectionAssert.AreEqual(new int[] { 0, 4, 7, 5, 2, 6, 1, 3 }, tab3);
    }

    public static void TestEsValido()
    {
        int[] tab = new int[4];
        Assert.IsTrue(EsValido(tab, 0, 0));
        Assert.IsTrue(EsValido(tab, 3, 3));
        Assert.IsFalse(EsValido(tab, -1, 0));
        Assert.IsFalse(EsValido(tab, 0, -1));
        Assert.IsFalse(EsValido(tab, 4, 0));
        Assert.IsFalse(EsValido(tab, 0, 4));
    }

    public static void TestValidMov()
    {
        int[] tab = new int[4] { 1, 3, 0, 2 };
        Assert.IsFalse(ValidMov(tab, 1, 0));
        Assert.IsFalse(ValidMov(tab, 2, 1));
        Assert.IsFalse(ValidMov(tab, 3, 2));
        Assert.IsTrue(ValidMov(tab, 0, 2));
    }

public static void ColocarReina(int[] tab, int pos, int fila)
{
  
    if(pos==0 && fila>tab.Length-1)
    {
      return;
    }

    if (fila > tab.Length - 1)
    {
        if(pos-1<0)
        {
          return;
        }
        else
        {
        
        ColocarReina(tab, pos - 1, tab[pos-1]+1);
        return ;
        }
    }


    if (EsValido(tab, pos, fila) && ValidMov(tab, pos, fila))
    {
        tab[pos] = fila;
        if (pos == tab.Length - 1)
        {
            // All queens have been placed on the board
            for(int i = 0 ; i<tab.Length;i++)
            {
              Console.WriteLine(tab[i]);
            }
            return;
        }
        ColocarReina(tab, pos + 1, 0);
    }
    else
    {  
        ColocarReina(tab, pos, fila + 1);
    }



}

       public static bool EsValido(int[] tab, int pos , int fila)
       {

         if(pos>=0 && pos<tab.Length && fila>=0 && fila<tab.Length)
         {
            return true;
         }
         else
         return false;

       }

       public static bool ValidMov(int[] tab, int columna , int fila)
      {
           
           for(int i= columna ;i>=0;i--)
           {
            if(tab[i]==fila)
            {
                return false; 
            }
           }

          
           for(int i= columna ;i>=0;i--)
           {
              if(Math.Abs(tab[i]-fila)==Math.Abs(i-columna))
              {
                return false;
              }
           }

           return true;
          

       }
          

}
}

