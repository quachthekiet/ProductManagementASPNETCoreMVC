﻿using BusinessObjects;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategories = new List<Category>();
            try
            {
                using var context = new MyStoreContext();
                listCategories = context.Categories.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }
    }
}
