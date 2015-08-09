/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using System.Collections.Generic;

namespace Daniel15.SimpleAuth
{
	/// <summary>
	/// Configuration section for SimpleAuth
	/// </summary>
	/// <typeparam name="TUser">Model type of the user</typeparam>
	public class Configuration<TUser> where TUser : SimpleAuthUser
	{
		/// <summary>
		/// Gets or sets all the users contained within the configuration.
		/// </summary>
		public Dictionary<string, TUser> Users { get; set; }
	}
}
