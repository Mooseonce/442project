using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class test_play_vcr
    {
        public GameObject vcr;
        public GameObject cartred, cartblue, envred, envblue, activeEnv, inactiveEnv;
        // A Test behaves as an ordinary method
        [Test]
        public void Test_VcrSimplePasses()
        {
            // Use the Assert class to test conditions
            

           // vcr.GetComponent<Vcr>().ChangeEnviroment(cartred);
        }
        [Test]
        public void Test_VcrLoadCart()
        {
            // Use the Assert class to test conditions
            envred = new GameObject();
            envred.AddComponent<Enviroment>();

            envred.GetComponent<Enviroment>().SetColorId(Color.red);
            envblue = new GameObject();
            envblue.AddComponent<Enviroment>();
            envblue.GetComponent<Enviroment>().SetColorId(Color.blue);
            vcr = new GameObject();
            vcr.AddComponent<Vcr>();
           
            vcr.GetComponent<Vcr>().AddToEnviromentList(Color.blue, envblue);
            vcr.GetComponent<Vcr>().AddToEnviromentList(Color.red, envred);

          //  vcr.GetComponent<Vcr>().enviromentPositions.Add(vcr.transform);
          //  vcr.GetComponent<Vcr>().enviromentPositions.Add(vcr.transform);
            cartblue = new GameObject();
            cartblue.AddComponent<Cartridge>();
            cartblue.GetComponent<Cartridge>().ConstructCartridge(Color.blue);
            cartred = new GameObject();
            cartred.AddComponent<Cartridge>();
            cartred.GetComponent<Cartridge>().ConstructCartridge(Color.red);
            vcr.GetComponent<Vcr>().ChangeEnviroment(cartred);
            Assert.IsNotNull(vcr.GetComponent<Vcr>().GetActiveEnviroment());
        }


        [Test]
        public void Test_VcrLoadTwoDifferentCart()
        {
            //Enviroment should equal the second cart

            // Use the Assert class to test conditions
            envred = new GameObject();
            envred.AddComponent<Enviroment>();

            envred.GetComponent<Enviroment>().SetColorId(Color.red);
            envblue = new GameObject();
            envblue.AddComponent<Enviroment>();
            envblue.GetComponent<Enviroment>().SetColorId(Color.blue);
            vcr = new GameObject();
            vcr.AddComponent<Vcr>();

            vcr.GetComponent<Vcr>().AddToEnviromentList(Color.blue, envblue);
            vcr.GetComponent<Vcr>().AddToEnviromentList(Color.red, envred);

            //  vcr.GetComponent<Vcr>().enviromentPositions.Add(vcr.transform);
            //  vcr.GetComponent<Vcr>().enviromentPositions.Add(vcr.transform);
            cartblue = new GameObject();
            cartblue.AddComponent<Cartridge>();
            cartblue.GetComponent<Cartridge>().ConstructCartridge(Color.blue);
            cartred = new GameObject();
            cartred.AddComponent<Cartridge>();
            cartred.GetComponent<Cartridge>().ConstructCartridge(Color.red);
            vcr.GetComponent<Vcr>().ChangeEnviroment(cartred);
            vcr.GetComponent<Vcr>().ChangeEnviroment(cartblue);
            Assert.AreNotEqual(vcr.GetComponent<Vcr>().GetActiveEnviroment(), envred);
        }

       






        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator test_play_vcrWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            
         
            yield return null;
        }
    }
}
