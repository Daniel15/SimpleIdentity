/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using Microsoft.AspNet.Identity;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;

namespace Daniel15.SimpleIdentity
{
	/// <summary>
	/// Extensions to <see cref="IdentityBuilder"/> allowing registration of SimpleIdentity services.
	/// </summary>
	public static class IdentityBuilderExtensions
	{
		/// <summary>
		/// Configures SimpleIdentity
		/// </summary>
		/// <typeparam name="TUser">Type of the user model.</typeparam>
		/// <param name="builder">Identity builder.</param>
		/// <param name="config">SimpleIdentity configuration section.</param>
		/// <returns>The identity builder</returns>
		public static IdentityBuilder AddSimpleIdentity<TUser>(this IdentityBuilder builder, IConfiguration config) where TUser : SimpleIdentityUser
		{
			builder.Services.Configure<Configuration<TUser>>(config);

			var userStoreType = typeof(UserStore<>).MakeGenericType(builder.UserType);
			var roleStoreType = typeof(RoleStore<>).MakeGenericType(builder.RoleType);
			builder.Services.AddSingleton(
				typeof(IUserStore<>).MakeGenericType(builder.UserType),
				userStoreType
			);
			builder.Services.AddSingleton(
				typeof(IRoleStore<>).MakeGenericType(builder.RoleType),
				roleStoreType
			);

			return builder;
		}
	}
}
