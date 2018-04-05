using System;
using System.ComponentModel;

namespace WpfPractise
{
    public class Employee : IDataErrorInfo
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                        result = "Please enter a Name";
                    
                    if(Name != null)
                    foreach (var c in Name)
                    {
                        int temp;
                        if (int.TryParse(c.ToString(), out temp))
                        {
                            result = "Please enter only char ";
                            return result;
                        }
                            
                    }


                   
                }
               
                return result;
            }
        }
    }
}