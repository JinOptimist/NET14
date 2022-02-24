using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb;


namespace TeamSocial
{
    public class UserSettings
    {
        private User _currentUser { get; set; }

        public UserSettings(User user) 
        {
            _currentUser = user;
        }

        public bool ChangeName(string firstname, string lastname) 
        {
            if (firstname == null || lastname == null ||
                firstname == null && lastname == null) 
            {
                throw new DataMisalignedException("Data cant be null!");
            }

            _currentUser.FirstName = firstname;
            _currentUser.LastName = lastname;
            return true;
        }

        public bool ChangeCountryAndOrCity(string country, string city) 
        {
            if (country == null || city == null ||
                country == null && city == null) 
            {
                throw new DataMisalignedException("Data cant be null!");
            }

            _currentUser.Country = country;
            _currentUser.City = city;
            return true;
        }

        public bool ChangeAge(int age) 
        {
            if (age == 0) 
            {
                throw new DataMisalignedException("Age cant be zero!");
            }
            _currentUser.Age = age;
            return true;
        }

        /*
         * Изменения Email пока нету, так как я хочу как-то проверить существует ли такой Email вообще
         */ 


    }
}
