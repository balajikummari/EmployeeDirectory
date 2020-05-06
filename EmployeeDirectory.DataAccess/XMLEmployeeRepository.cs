using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Models;
using System.Xml.Linq;

namespace EmployeeDirectory.DataAccess
{
    public class XMLEmployeeRepository : IRepository<Employee>
    {
        private readonly XDocument doc;
        private readonly string xmlFilePath;

        public XMLEmployeeRepository(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
            doc = XDocument.Load(xmlFilePath);
        }

        public Employee GetById(int id)
        {
            return GetElementById(id)?.FromXElement<Employee>();
        }

        public void Change(Employee newEntity)
        {
            var entityById = GetElementById(newEntity.Id);
            entityById.Attribute("FirstName").Value = newEntity.FirstName;
            entityById.Attribute("LastName").Value = newEntity.LastName;
            entityById.Attribute("Age").Value = newEntity.Age.ToString();
            entityById.Attribute("EmailAddress").Value = newEntity.EmailAddress;
        }

        public void Add(Employee entity)
        {
            Random rnd = new Random();
            entity.Id = (int)rnd.Next();
            var element = entity.ToXElement<Employee>();
            doc.Root.Add(element);
        }

        public void Remove(int id)
        {
            var entityById = GetElementById(id);
            entityById.Remove();
        }

        public IEnumerable<Employee> GetAll()
        {
            return doc.Descendants("Employee").Select(element => element.FromXElement<Employee>());
        }

        public void SaveChanges()
        {
            doc.Save(xmlFilePath);
        }

        private XElement GetElementById(int id)
        {
            var result =  doc.Descendants("Employee")
                         .Where(element => element.FromXElement<Employee>().Id == id).FirstOrDefault();
            return result;
        }
    }
}
