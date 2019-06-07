using Caliburn.Micro;
using CvGenerator.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CvGenerator.ViewModels
{
    public class ShellViewModel : Screen
    {
        public List<PersonModel> people { get; set; } = new List<PersonModel>();

        #region Assingning Personal Data
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => ID);
            }
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private string _surname = "";
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                NotifyOfPropertyChange(() => Surname);
            }
        }

        private string _city = "";
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        private string _country = "";
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        private string _email = "";
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        private string _date = "";
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        private string _school = "";
        public string School
        {
            get
            {
                return _school;
            }
            set
            {
                _school = value;
                NotifyOfPropertyChange(() => School);
            }
        }

        private string _experience = "";
        public string Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
                NotifyOfPropertyChange(() => Experience);
            }
        }

        /// <summary>
        /// property which only passes value to Experience
        /// </summary>
        private string _changingExperience = "";
        public string ChangingExperience
        {
            get
            {
                return _changingExperience;
            }
            set
            {
                _changingExperience = value;
                NotifyOfPropertyChange(() => ChangingExperience);
            }
        }

        private string _skills = "";
        public string Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                NotifyOfPropertyChange(() => Skills);
            }
        }

        /// <summary>
        /// property which only passes value to Skills
        /// </summary>
        private string _changingSkills = "";
        public string ChangingSkills
        {
            get
            {
                return _changingSkills;
            }
            set
            {
                _changingSkills = value;
                NotifyOfPropertyChange(() => ChangingSkills);
            }
        }

        #endregion

        #region Visibility of label "Your Previous Data"
        private Visibility labelVisibility;

        public Visibility LabelVisibility
        {
            get
            {
                if (people.Count == 0) labelVisibility = Visibility.Hidden;
                else labelVisibility = Visibility.Visible;
                return labelVisibility;
            }
        }
        #endregion

        public ShellViewModel()
        {
            LoadPeopleList();
        }

        #region Experience and Skills textboxes view methods
        public void AddExperience()
        {
            Experience += "- " + ChangingExperience + "\n";
            ChangingExperience = "";
        }

        public void AddSkills()
        {
            Skills += "- " + ChangingSkills + "\n";
            ChangingSkills = "";
        }
        #endregion

        #region Exporting to PDF

        /// <summary>
        /// Method which creates object of PDFExporter class and evokes method ExportCvToPdf, 
        /// passing 8 argumnents from Personal Data
        /// </summary>
        public void ExportToPDF()
        {
            if (AreAllFIeldsFilled())
            {
                PDFExporter exporter = new PDFExporter();
                exporter.ExportCvToPDF(Name, Surname, City, Country, PhoneNumber, Email, Date, School, Experience, Skills);
            }
            else
            {
                MessageBoxResult wynik = MessageBox.Show("Firstly, fill all fields above", "Warning",
                MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.None);
            }
        }
        
        private bool AreAllFIeldsFilled()
        {
            if (Name != "" && Surname != "" && City != "" && Country != "" && PhoneNumber != "" && 
                Email != "" && Date != "" && School != "" && Experience != "" && Skills != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Saving data to DataBase: PersonalData.db
        private void LoadPeopleList()
        {
            people = SQLiteDataAcces.LoadPeople();               
        }

        public void SaveToBase()
        {
            if (AreAllFIeldsFilled())
            {
                PersonModel p = new PersonModel();

                p.Name = Name;
                p.Surname = Surname;
                p.City = City;
                p.Country = Country;
                p.PhoneNumber = PhoneNumber;
                p.Email = Email;
                p.Date = Date;
                p.School = School;
                p.Experience = Experience;
                p.Skills = Skills;

                SQLiteDataAcces.SavePerson(p);

                Name = "";
                Surname = "";
                City = "";
                Country = "";
                PhoneNumber = "";
                Email = "";
                Date = "";
                School = "";
                Experience = "";
                Skills = "";

                LoadPeopleList(); 
            }
            else
            {
                MessageBoxResult wynik = MessageBox.Show("Firstly, fill all fields above", "Warning",
                MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.None);
            }
           
        }
        #endregion
        
        public void SelectedItem(PersonModel personModel)
        {
            LoadSelectedItem(personModel.Name, personModel.Surname, personModel.City, personModel.Country, personModel.PhoneNumber, personModel.Email, personModel.Date, personModel.School, personModel.Experience, personModel.Skills);
        }

        public void LoadSelectedItem(string name, string surname, string city, string country, string phoneNumber, string email, string date, string school, string experience, string skills)
        {
            Name = name;
            Surname = surname;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Email = email;
            Date = date;
            School = school;
            Experience = experience;
            Skills = skills;
        }
    }
}
