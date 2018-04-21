using System.Collections.Generic;
using UnityEngine;

public static class ChartLoader {
	public static Dictionary<int,char> LoadChart(TextAsset file) {
		var chart = new Dictionary<int,char>();
		foreach (var entry in file.text.Split('\n')) {
			if (entry == "") continue;
			var parts = entry.Split(';');
			var timestamp = int.Parse(parts[0]);
			var steptype = parts[1][0];
			chart.Add(timestamp, steptype);
		}
		return chart;
	}
}
