/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using System.Collections.Generic;

namespace Daniel15.SimpleIdentity
{
	/// <summary>
	/// Configuration section for SimpleIdentity
	/// </summary>
	/// <typeparam name="TUser">Model type of the user</typeparam>
	public class Configuration<TUser> where TUser : SimpleIdentityUser
	{
		/// <summary>
		/// Gets or sets all the users contained within the configuration.
		/// </summary>
		public Dictionary<string, TUser> Users { get; set; }
	}
}
