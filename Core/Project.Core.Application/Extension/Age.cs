﻿using System;

namespace Project.Core.Application.Extension
{
    public static class Age
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
