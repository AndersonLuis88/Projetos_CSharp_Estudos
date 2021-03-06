﻿using System;
using System.Linq;
using System.Collections.Generic;
using LinQ.Entities;
using System.IO;
using System.Globalization;
namespace LinQ
{
    class Program
    {
        //static void Print<T>(string message, IEnumerable<T> collection)
        //{
        //   Console.WriteLine(message);
        //    foreach(T obj in collection)
        //    {
        //        Console.WriteLine(obj);
        //    }
        //}
        static void Main(string[] args)
        {

            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    list.Add(new Product(name, price));

                }
            }
        }
    }
}































/*Specify the data source
int[] numbers = new int[] { 2, 3, 4, 5 };

Define the query expression
IEnumerable<int> result = numbers
    .Where(x => x % 2 == 0)
    .Select(x => x * 10);

Execute the query
foreach (int x in result)
{
    Console.WriteLine(x);
}
//---------------------------------------

Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

List<Product> products = new List<Product>
{
    new Product() {Id=1, Name = "Computer", Price = 1100.0, Category = c2},
    new Product() {Id=2, Name = "Hammer", Price = 90.0, Category = c1},
    new Product() {Id=3, Name = "TV", Price = 1700.0, Category = c3},
    new Product() {Id=4, Name = "Notebook", Price = 1300.0, Category = c2},
    new Product() {Id=5, Name = "Saw", Price = 80.0, Category = c1},
    new Product() {Id=6, Name = "Tablet", Price = 700.0, Category = c2},
    new Product() {Id=7, Name = "Camera", Price = 700.0, Category = c3},
    new Product() {Id=8, Name = "Printer", Price = 350.0, Category = c3},
    new Product() {Id=9, Name = "Macbook", Price = 1800.0, Category = c2},
    new Product() {Id=10, Name = "Sound Bar", Price = 700.0, Category = c3},
    new Product() {Id=11, Name = "Level", Price = 70.0, Category = c1},
};

//var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
var r1 =
    from p in products
    where p.Category.Tier == 1 && p.Price < 900.0
    select p;
Print("Tier 1 and price < 900: ", r1);
Console.WriteLine();

//var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
var r2 =
    from p in products
    where p.Category.Name == "Tools"
    select p.Name;
Print("Names of products from tools ", r2);
Console.WriteLine();

//var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
var r3 =
    from p in products
    where p.Name[0] == 'C'
    select new
    {
        p.Name,
        p.Price,
        CategoryName = p.Category.Name

    };
Print("Names started with 'C' and anonymous object", r3);
Console.WriteLine();

//var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
var r4 =
    from p in products
    where p.Category.Tier == 1
    orderby p.Name
    orderby p.Price
    select p;
Print("Tier 1 Order By Price Then By Name", r4);
Console.WriteLine();

//var r5 = r4.Skip(2).Take(4);
var r5 =
    (from p in r4
     select p).Skip(2).Take(4);
Print("Tier 1 Order By Price Then By Name, Skip 2 Take 4", r5);
Console.WriteLine();

var r6 = (from p in products select p).FirstOrDefault();
Console.WriteLine("First or Default: " + r6);
Console.WriteLine();

var r7 = 
    (from p in products
     where p.Price > 3000.0
     select p).FirstOrDefault();
Console.WriteLine("First or Default: " + r7);
Console.WriteLine();

var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
Console.WriteLine("Single or Default: " + r8);
Console.WriteLine();

var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
Console.WriteLine("Single or Default: " + r9);
Console.WriteLine();

//Agregação e agrupamento

var r10 = products.Max(p => p.Price);
Console.WriteLine("Max product price: " + r10);
Console.WriteLine();

var r11 = products.Min(p => p.Price);
Console.WriteLine("Max product price: " + r11);
Console.WriteLine();

var r12 = products.Where(p => p.Category.Id == 1).Sum(p=> p.Price);
Console.WriteLine("Sum price of category 1: " + r12);
Console.WriteLine();

var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
Console.WriteLine("Average price of category 1: " + r13);
Console.WriteLine();

var r14 = products.Where(p => p.Category.Id == 5).Select(p=> p.Price).DefaultIfEmpty(0.0).Average();
Console.WriteLine("Average price of category 1: " + r14);
Console.WriteLine();

var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
Console.WriteLine("Aggregate sum: " + r15);
Console.WriteLine();

//var r16 = products.GroupBy(p => p.Category);
var r16 =
    from p in products
    group p by p.Category;
foreach (IGrouping<Category,Product> group in r16)
{
    Console.WriteLine("Category " + group.Key.Name + ":" ) ;
    foreach (Product p in group)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
}
*/

