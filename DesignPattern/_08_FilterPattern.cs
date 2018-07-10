using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesignPattern._08_Filter
{
    [DataContract(Name = "过滤器模式")]
    public class _08_FilterPattern
    {
        public static void Run()
        {
            Console.WriteLine(typeof(_08_FilterPattern).GetClassName());

            List<Person> persons = new List<Person>
            {
                new Person("Robert", "Male", "Single"),
                new Person("John", "Male", "Married"),
                new Person("Laura", "Female", "Married"),
                new Person("Diana", "Female", "Single"),
                new Person("Mike", "Male", "Single"),
                new Person("Bobby", "Male", "Single")
            };

            ICriteria male = new CriteriaMale();
            ICriteria female = new CriteriaFemale();
            ICriteria single = new CriteriaSingle();
            ICriteria singleMale = new AndCriteria(single, male);
            ICriteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males:");
            PrintPersons(male.MeetCriteria(persons));

            Console.WriteLine("FeMales:");
            PrintPersons(female.MeetCriteria(persons));

            Console.WriteLine("Single Males:");
            PrintPersons(singleMale.MeetCriteria(persons));

            Console.WriteLine("Single Or Males:");
            PrintPersons(singleOrFemale.MeetCriteria(persons));

            Console.WriteLine();
        }
        
        private static void PrintPersons(List<Person> persons)
        {
            foreach (Person item in persons)
                Console.WriteLine($"Person:[{item.Name},\t{item.Gender},\t{item.MaritalStatus}]");
            Console.WriteLine();
        }
    }
    public class Person
    {
        public readonly string Name;
        public readonly string Gender;
        public readonly string MaritalStatus;
        public Person(string name, string gender, string marital)
        {
            Name = name;
            Gender = gender;
            MaritalStatus = marital;
        }
    }

    public interface ICriteria
    {
        List<Person> MeetCriteria(List<Person> person);
    }

    public class CriteriaMale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (var item in persons)
            {
                if (item.Gender.ToLower().Equals("MALE".ToLower()))
                    malePersons.Add(item);
            }
            return malePersons;
        }
    }

    public class CriteriaFemale : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();
            foreach (var item in persons)
            {
                if (item.Gender.ToLower().Equals("FEMALE".ToLower()))
                    femalePersons.Add(item);
            }
            return femalePersons;
        }
    }

    public class CriteriaSingle : ICriteria
    {
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();
            foreach (var item in persons)
            {
                if (item.MaritalStatus.ToLower().Equals("SINGLE".ToLower()))
                    singlePersons.Add(item);
            }
            return singlePersons;
        }
    }

    public class AndCriteria : ICriteria
    {
        private ICriteria _criteria;
        private ICriteria _otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            _criteria = criteria;
            _otherCriteria = otherCriteria;
        }
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = _criteria.MeetCriteria(persons);
            return _otherCriteria.MeetCriteria(persons);
        }
    }

    public class OrCriteria : ICriteria
    {
        private ICriteria _criteria;
        private ICriteria _otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            _criteria = criteria;
            _otherCriteria = otherCriteria;
        }
        public List<Person> MeetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = _criteria.MeetCriteria(persons);
            List<Person> otherCriteriaItems = _otherCriteria.MeetCriteria(persons);
            foreach (var item in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(item)) firstCriteriaItems.Add(item);
            }
            return firstCriteriaItems;
        }
    }


}