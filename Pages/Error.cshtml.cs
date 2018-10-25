// <copyright file="Error.cshtml.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp.Pages
{
	using System.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.RazorPages;

	public class ErrorModel : PageModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public void OnGet()
		{
			this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
		}
	}
}
