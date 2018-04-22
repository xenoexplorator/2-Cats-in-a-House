using System.Collections.Generic;
using UnityEngine;

public static class ChartLoader {
	public static Dictionary<int,int> LoadChart(TextAsset file) {
		var chart = new Dictionary<int,int>();
		foreach (var entry in file.text.Split('\n')) {
			if (entry == "" || entry[0] == '#') continue;
			var timestamp = int.Parse(entry);
			var steptype = Random.Range(0,4);
			chart.Add(timestamp, steptype);
		}
		return chart;
	}

    public static Dictionary<int, int> LoadWave(TextAsset file)
    {
        var absTime = 0;
        var chart = new Dictionary<int, int>();
        foreach (var entry in file.text.Split('\n'))
        {
            if (entry == "" || entry[0] == '#') continue;
            var items = entry.Split(';');
            var timestamp = (absTime + int.Parse(items[0]));
            absTime = timestamp;
            var monsterType = int.Parse(items[1]);
            chart.Add(timestamp, monsterType);
        }
        return chart;
    }
}
