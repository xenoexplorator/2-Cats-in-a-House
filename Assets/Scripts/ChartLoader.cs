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
}
