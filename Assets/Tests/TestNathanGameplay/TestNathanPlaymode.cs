using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestNathanPlaymode
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestNathanSimplePasses()
    {
        //arrange
        GameObject player = new GameObject();
        PlayerHealth playerHealth = player.AddComponent<PlayerHealth>();

        int baseHP = playerHealth.HP;
        bool eventInvoked = false;
        playerHealth.OnHealthChanged += (int h) => eventInvoked = true;
        //act

        playerHealth.OnDamageTaken(Random.insideUnitSphere * Random.value * 1000);

        //assert
        Assert.That(playerHealth.HP, Is.LessThan(baseHP),$"les HPs ont pas baissé. Base HP : {baseHP} , new HP : {playerHealth.HP}");
        Assert.That(eventInvoked, Is.True,"OnHealthChanged Event wasn't invoked");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestNathanWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
