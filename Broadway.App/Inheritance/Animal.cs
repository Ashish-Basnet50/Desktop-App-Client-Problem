using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.App.Inheritance
{

    public class LivingThing
    {
        public LivingThing()
        {
                
        }

        public LivingThing(string Name)
        {

        }

        protected string LivingThingName = "";
        private string privateLivingThingName = "";
        public string publicLivingThingName = "";
    }


    public class Animal:LivingThing
    {
        public Animal()
        {

        }

        public Animal(string Name):base(Name)
        {

        }


        public string publicName = "";
        protected string protectedName = "";
        private string privateName = "";

        public void Test()
        {
            
        }

    }

    public class Vertibrate : Animal
    {

        public Vertibrate()
        {

        }

        public Vertibrate(string Name):base(Name)
        {

        }
       private void Test()
        {
            publicName = "";
            protectedName = "";
            LivingThingName="";
            
        }

    }

    public class Plant:LivingThing
    {

    }
}
