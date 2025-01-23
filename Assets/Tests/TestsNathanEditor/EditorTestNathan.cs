using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditorTestNathan
{
    // A Test behaves as an ordinary method
    [Test]
    public void EditorTestNathanSimplePasses()
    {
        //arrange
        Vector3 v = Random.insideUnitSphere * Random.value * 100;
        Vector3 u = Random.insideUnitSphere * Random.value * 100;
        
        //act
        float d = v.SqrDistanceTo(u);

        //assert
        float ecart = Mathf.Abs(d - Mathf.Pow(Vector3.Distance(u, v), 2));
        Assert.That( ecart , Is.AtMost(.001f ));
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EditorTestNathanWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
