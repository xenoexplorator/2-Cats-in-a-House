using System.Collections.Generic;
using UnityEngine;

public static class ChartLoader {
	public static Dictionary<int,char> LoadChart(TextAsset file, float ticksPer4th) {
		var chart = new Dictionary<int,char>();
		foreach (var entry in file.text.Split('\n')) {
			if (entry == "") continue;
			var parts = entry.Split(';');
			var timestamp = (int)(int.Parse(parts[0]) * ticksPer4th);
			var steptype = parts[1][0];
			chart.Add(timestamp, steptype);
		}
		return chart;
	}
}
