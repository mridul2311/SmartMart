using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product
{
    public int pid;
    public float rate;
    public float discount;
    public float amount;
    public string pname;
    public float tax;
    public int quantity;
    public float discount_amount;
    public float total_amount;
    public int stock;

    public Product(int pid, string pname, float rate, float tax, float discount)
    {
        this.pid = pid;
        this.pname = pname;
        this.rate = rate;
        this.tax = tax;
        this.discount = discount;
        quantity = 1;

        
        total_amount = rate;
    }

    public void Increment()
    {
        quantity++;
    }

   
    public void Decrement()
    {
        if(quantity>0)
            quantity--;
    }

   

    public string display()
    {
        return "\n" + pid + " " + pname + " " + rate + " " + tax+" "+quantity;
    }

    public int getPid()
    {
        return pid;
    }

    public float getRate()
    {
        return rate;
    }

    public string getName()
    {
        return pname;
    }

    public float getTax()
    {
        return tax;
    }

    public int getQuantity()
    {
        return quantity;
    }

    public float getDiscountAmount()
    {
        return discount_amount;
    }

    public float getAmount()
    {
        return amount;
    }

    public float getDiscount()
    {
        return discount;
    }

    public float getTotalAmount()
    {
        return total_amount;
    }

}
