/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

namespace Daniel15.SimpleIdentity
{
	/// <summary>
	/// A user in SimpleIdentity
	/// </summary>
	public class SimpleIdentityUser
	{
		/// <summary>
		/// Gets or sets the user's email address.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the user's normalized email address.
		/// </summary>
		public string NormalizedUserName { get; set; }

		/// <summary>
		/// Gets or sets the user's hashed password.
		/// </summary>
		public string PasswordHash { get; set; }
	}
}
