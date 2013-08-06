using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace Betfair.Utilities
{
    public class RaceCourseAbreviations
    {
        public static Course[] RaceCourses;

        public RaceCourseAbreviations()
        {
            if (RaceCourses == null)
            {
                LoadAbreviationsFromFile(true);
            }
            else
            {
                LoadAbreviationsFromFile(false);
            }
        }

        private static void LoadAbreviationsFromFile(bool forceReload)
        {
            if (RaceCourses != null && !forceReload) return;
            
            var results = new ArrayList();

            var resources =
                Assembly.GetAssembly(typeof (RaceCourseAbreviations)).GetManifestResourceNames();
            
            var assembly = Assembly.GetAssembly(typeof (RaceCourseAbreviations));

            if (assembly == null) return;

            using (var sr = new StreamReader(assembly.GetManifestResourceStream(resources[0])))
            {
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    temp = temp.Trim();
                    if (temp.Length > 0 &&
                        !temp.Contains("#") &&
                        temp.Contains(","))
                    {
                        string[] tempArray = temp.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        if (tempArray.Length >= 2)
                        {
                            var course = new Course
                                             {
                                                 Name = tempArray[0],
                                                 Abreviation = tempArray[1],
                                                 FlattenedName = tempArray[0]
                                             };
                            // Flatten this name
                            course.FlattenedName = course.FlattenedName.Replace(" ", "");
                            course.FlattenedName = course.FlattenedName.Replace(" ", "");
                            course.FlattenedName = course.FlattenedName.Replace("'", "");
                            course.FlattenedName = course.FlattenedName.Replace(",", "");
                            course.FlattenedName = course.FlattenedName.Replace("~", "");
                            var tab = '\u0009';
                            course.FlattenedName = course.FlattenedName.Replace(tab.ToString(), "");
                            course.FlattenedName = course.FlattenedName.ToLower();

                            results.Add(course);
                        }
                    }
                }

                RaceCourses = new Course[results.Count];
                int count = 0;
                foreach (Course course in results)
                {
                    RaceCourses[count] = course;
                    count++;
                }
            }
        }

        /// <summary>
        /// Get the race course fullname from the betfair abreviation
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public string GetRaceCourseName(string searchString)
        {
            string response = null;

            foreach (Course course in RaceCourses)
            {
                //Clean up the searchString// Flatten this name
                searchString = searchString.Replace(" ", "");
                searchString = searchString.Replace(" ", "");
                searchString = searchString.Replace("'", "");
                searchString = searchString.Replace(",", "");
                searchString = searchString.Replace("~", "");
                const char tab = '\u0009';
                searchString = searchString.Replace(tab.ToString(), "");
                searchString = searchString.ToLower();

                //Try to find a match
                if (searchString.IndexOf(course.Abreviation.ToLower()) > -1)
                {
                    response = course.Abreviation;
                    break;
                }
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public string GetRaceCourseAbreviation(string searchString)
        {
            string response = null;

            foreach (Course course in RaceCourses)
            {
                //Clean up the searchString// Flatten this name
                searchString = searchString.Replace(" ", "");
                searchString = searchString.Replace(" ", "");
                searchString = searchString.Replace("'", "");
                searchString = searchString.Replace(",", "");
                searchString = searchString.Replace("~", "");
                const char tab = '\u0009';
                searchString = searchString.Replace(tab.ToString(), "");
                searchString = searchString.ToLower();

                //Try to find a match
                if (searchString.IndexOf(course.FlattenedName) > -1)
                {
                    response = course.Abreviation;
                    break;
                }
            }
            return response;
        }

        /// <summary>
        /// Search for the full name of a race course based on the Betfair abreviation
        /// </summary>
        /// <param name="abreviation">The abreviation.</param>
        /// <returns></returns>
        public Course GetRaceCourse(string abreviation)
        {
            Course response = null;

            foreach (var course in RaceCourses)
            {
                //Clean up the searchString// Flatten this name
                abreviation = abreviation.Replace(" ", "");
                abreviation = abreviation.Replace(" ", "");
                abreviation = abreviation.Replace("'", "");
                abreviation = abreviation.Replace(",", "");
                abreviation = abreviation.Replace("~", "");
                var tab = '\u0009';
                abreviation = abreviation.Replace(tab.ToString(), "");
                abreviation = abreviation.ToLower();

                //Try to find a match
                if (abreviation.IndexOf(course.Abreviation.ToLower()) <= -1) continue;
                
                response = course;
                break;
            }
            return response;
        }

        /// <summary>
        /// Returns a complete list of race courses stored
        /// </summary>
        /// <returns></returns>
        public Course[] GetAllRaceCourseAbreviations()
        {
            return RaceCourses;
        }

        /// <summary>
        /// Use the menu path returned in Betfair to try and get the course abreviation
        /// </summary>
        /// <param name="menuPath"></param>
        /// <returns></returns>
        public string GetCourseAbreviationFromBetfairMenuPath(string menuPath)
        {
            string[] tempArray1 = menuPath.Split("\\".ToCharArray());
            string[] tempArray2 = tempArray1[(tempArray1.Length - 1)].Split(" ".ToCharArray());
            return tempArray2[0].Trim();
        }

        #region Nested type: Course

        public class Course
        {
            public string Abreviation;
            public string FlattenedName;
            public string Name;
        }

        #endregion
    }
}