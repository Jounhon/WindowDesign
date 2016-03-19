using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ordering_System.Model
{
    public class CategoryControl
    {
        const string CATEGORY_FILE_NAME = "/defaultCategory.txt";
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        private List<Category> _categoryList = new List<Category>();

        // load category list
        public void InitializeCategoryList()
        {
            StreamReader file = new StreamReader(_projectPath + CATEGORY_FILE_NAME);
            string name;
            while ((name = file.ReadLine()) != null)
            {
                if (name == "")
                    continue;
                AddCategory(name);
            }
            file.Close();
        }

        // save category list to file
        public void SaveCategoryListToFile()
        {
            StreamWriter file = new StreamWriter(_projectPath + CATEGORY_FILE_NAME);
            List<Category> list = GetCategoryList();
            for (int index = 0; index < list.Count; index++)
            {
                file.WriteLine(list[index].Name);
            }
            file.WriteLine("");
            file.Close();
        }

        // add category
        public bool AddCategory(string name)
        {
            foreach (Category item in _categoryList)
            {
                if (item.Name.Equals(name))
                    return false;
            }
            Category category = new Category();
            category.Name = name;
            _categoryList.Add(category);
            return true;
        }

        // change category name
        public void ChangeCategoryName(string originalName, string newName)
        {
            foreach (Category item in _categoryList)
            {
                if (item.Name.Equals(originalName))
                    item.Name = newName;
            }
        }

        // get category list
        public List<Category> GetCategoryList()
        {
            return _categoryList;
        }

        // get category by name
        public Category GetCategoryByName(string name)
        {
            foreach (Category item in _categoryList)
            {
                if (item.Name.Equals(name))
                    return item;
            }
            return null;
        }

        // remove category
        public void RemoveCategory(Category item)
        {
            _categoryList.Remove(item);
        }
    }
}
