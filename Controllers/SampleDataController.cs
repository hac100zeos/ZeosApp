// <copyright file="SampleDataController.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;

	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		private static readonly string[] Summaries =
		{
			"Freezing",
			"Bracing",
			"Chilly",
			"Cool",
			"Mild",
			"Warm",
			"Balmy",
			"Hot",
			"Sweltering",
			"Scorching",
		};

		[HttpGet("[action]")]
		public IEnumerable<WeatherForecast> WeatherForecasts()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				DateFormatted = DateTime.Now.AddDays(index).ToString("d", new CultureInfo("en")),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)],
			});
		}

		public class WeatherForecast
		{
			public string DateFormatted { get; set; }

			public int TemperatureC { get; set; }

			public string Summary { get; set; }

			public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
		}
	}
}
