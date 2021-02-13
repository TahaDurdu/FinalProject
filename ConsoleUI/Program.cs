using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI

    //SOLID
    //O= OPEN CLOSED PRİNCİPLE =YENİ BİR ÖZELLİK EKLİYORSAN MEVCUT KODUNA DOKUNMAZSIN 
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
           // CategoryTest();
        }

        private static void CategoryTwst()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetail())
            {
                Console.WriteLine(product.ProductName+ "/"+ product.CategoryName);
            }
        }
    }
}
