using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moderato;
using Moderato.Collections;
using System.Linq;

public class Test : MonoBehaviour
{
    #region xxHash
    [Header("xxHash")]
    [SerializeField]
    private bool executeXXHashTest = true;
    [SerializeField]
    private uint xxHashSeed = 31531U;
    [SerializeField]
    private uint xxHashTestCount = 1000U;
    #endregion

    #region Random
    [Header("Random")]
    [SerializeField]
    private bool executeRandomTest = true;
    [SerializeField]
    private uint randomSeed = 60443;
    [SerializeField]
    private uint randomTestCount = 1000U;
    #endregion

    #region Random Range
    [Header("Random Range")]
    [SerializeField]
    private bool executeRandomRangeTest = true;
    [SerializeField]
    private uint randomRangeSeed = 60443U;
    [SerializeField]
    private uint randomRangeTestCount = 1000U;
    [SerializeField]
    private Vector2Int randomRange = new(0, 100);
    #endregion

    void Start()
    {
        if (executeXXHashTest)
        {
            TestXXHash();
        }
        if (executeRandomTest)
        {
            TestRandom();
        }
        if (executeRandomRangeTest)
        {
            TestRandomRange();
        }
    }

    private void TestXXHash()
    {
        List<uint> hashs = new();

        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        for (uint i = 0; i < xxHashTestCount; i++)
        {
            hashs.Add(xxHash.Hash32(i, xxHashSeed));
        }

        sw.Stop();

        // Display the hash test results
        long elapsedTicks = sw.ElapsedTicks;
        double elapsedSec = elapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency;
        Debug.Log($"Hash test elapsed {elapsedSec} sec");

        Debug.Log($"Not same hash count: {hashs.Distinct().Count()}");
    }

    private void TestRandom()
    {
        List<int> results = new();

        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        var random = new Moderato.Random(randomSeed);
        for (uint i = 0; i < randomTestCount; i++)
        {
            int result = random.Next();

            results.Add(result);
        }

        sw.Stop();

        // Display the random test results
        long elapsedTicks = sw.ElapsedTicks;
        double elapsedSec = elapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency;
        Debug.Log($"Random test elapsed {elapsedSec} sec");
    }

    private void TestRandomRange()
    {
        List<int> results = new();

        var sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        var random = new Moderato.Random(randomRangeSeed);
        for (uint i = 0; i < randomRangeTestCount; i++)
        {
            int result = random.Range(randomRange);

            results.Add(result);
        }

        sw.Stop();

        // Display the random range test results
        long elapsedTicks = sw.ElapsedTicks;
        double elapsedSec = elapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency;
        Debug.Log($"Random range test elapsed {elapsedSec} sec");
    }
}
