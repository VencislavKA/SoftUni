using Exercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new HospitalContext();
            var pts = db.Patient.Select(x=>x).Where(x=>x.FirstName == "hihihih");
            
            foreach (var pt in pts)
            {
                Console.WriteLine(pt.FirstName);
            }
        }
    }
}
