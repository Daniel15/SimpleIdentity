/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Daniel15.SimpleIdentity.Setup
{
	/// <summary>
	/// Setup program for SimpleIdentity. Allows you to configure your username and password.
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine(
				"Setup for SimpleIdentity. Enter your details and the relevant config section will "+
				"be generated. Note that your password will be displayed as you enter it."
			);
			var email = Prompt("Email");
			var password = Prompt("Password");
			Console.WriteLine();

			var user = CreateUser(email, password);
			var configSection = new
			{
				Users = new Dictionary<string, SimpleIdentityUser> {{user.NormalizedUserName, user}},
			};
			var serializedConfig = JsonConvert.SerializeObject(configSection, Formatting.Indented);
			Console.WriteLine(serializedConfig);
			Console.Read();
		}

		/// <summary>
		/// Creates a user model with the specified email address and password.
		/// </summary>
		/// <param name="email">Email address of the user</param>
		/// <param name="password">Password of the user</param>
		/// <returns></returns>
		private static SimpleIdentityUser CreateUser(string email, string password)
		{
			var normalizer = new UpperInvariantLookupNormalizer();
			var user = new SimpleIdentityUser
			{
				Email = email,
				NormalizedUserName = normalizer.Normalize(email),
			};
			var hasher = new PasswordHasher<SimpleIdentityUser>();
			user.PasswordHash = hasher.HashPassword(user, password);
			return user;
		}

		/// <summary>
		/// Displays the specified prompt and allow the user to enter a value
		/// </summary>
		/// <param name="prompt">Prompt to display</param>
		/// <returns>Value entered by the user</returns>
		private static string Prompt(string prompt)
		{
			Console.Write("{0}: ", prompt);
			return Console.ReadLine().Trim();
		}
	}
}
