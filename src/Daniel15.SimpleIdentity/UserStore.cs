/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Daniel15.SimpleIdentity
{
	/// <summary>
	/// The user store in SimpleIdentity. Handles retrieving user data from the configuration.
	/// </summary>
	/// <typeparam name="TUser">Type of the user model</typeparam>
	public class UserStore<TUser> : 
		IUserPasswordStore<TUser>, 
		IUserEmailStore<TUser>, 
		IQueryableUserStore<TUser>
		where TUser : SimpleIdentityUser
	{
		private readonly Configuration<TUser> _config;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserStore{TUser}" /> class.
		/// </summary>
		/// <param name="config">The configuration to use</param>
		public UserStore(IOptions<Configuration<TUser>> config)
		{
			_config = config.Value;
		}

		/// <summary>
		/// Gets the user identifier for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose identifier should be retrieved.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the identifier for the specified <paramref name="user"/>.
		/// </returns>
		public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.NormalizedUserName);
		}

		/// <summary>
		/// Gets the user name for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose name should be retrieved.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the name for the specified <paramref name="user"/>.
		/// </returns>
		public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Email);
		}

		/// <summary>
		/// Gets the normalized user name for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose normalized name should be retrieved.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the normalized user name for the specified <paramref name="user"/>.
		/// </returns>
		public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.NormalizedUserName);
		}

		/// <summary>
		/// Finds and returns a user, if any, who has the specified <paramref name="userId"/>.
		/// </summary>
		/// <param name="userId">The user ID to search for.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID"/> if it exists.
		/// </returns>
		public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			return FindByNameAsync(userId, cancellationToken);
		}

		/// <summary>
		/// Finds and returns a user, if any, who has the specified normalized user name.
		/// </summary>
		/// <param name="normalizedUserName">The normalized user name to search for.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID"/> if it exists.
		/// </returns>
		public Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			TUser user;
			_config.Users.TryGetValue(normalizedUserName, out user);
			return Task.FromResult(user);
		}

		/// <summary>
		/// Gets the password hash for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose password hash to retrieve.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, returning the password hash for the specified <paramref name="user"/>.
		/// </returns>
		public Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.PasswordHash);
		}

		/// <summary>
		/// Gets a flag indicating whether the specified <paramref name="user"/> has a password, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user to return a flag for, indicating whether they have a password or not.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, returning true if the specified <paramref name="user"/> has a password
		///			 otherwise false.
		/// </returns>
		public Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
		}

		/// <summary>
		/// Gets the email address for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email should be returned.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object containing the results of the asynchronous operation, the email address for the specified <paramref name="user"/>.
		/// </returns>
		public Task<string> GetEmailAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Email);
		}

		/// <summary>
		/// Gets a flag indicating whether the email address for the specified <paramref name="user"/> has been verified, true if the email address is verified otherwise
		///			 false, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email confirmation status should be returned.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object containing the results of the asynchronous operation, a flag indicating whether the email address for the specified <paramref name="user"/>
		///			 has been confirmed or not.
		/// </returns>
		public Task<bool> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// Gets the user, if any, associated with the specified, normalized email address, as an asynchronous operation.
		/// </summary>
		/// <param name="normalizedEmail">The normalized email address to return the user for.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object containing the results of the asynchronous lookup operation, the user if any associated with the specified normalized email address.
		/// </returns>
		public Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			return FindByNameAsync(normalizedEmail, cancellationToken);
		}

		/// <summary>
		/// Returns the normalized email for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email address to retrieve.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object containing the results of the asynchronous lookup operation, the normalized email address if any associated with the specified user.
		/// </returns>
		public Task<string> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken)
		{
			return GetNormalizedUserNameAsync(user, cancellationToken);
		}

		/// <summary>
		/// Returns an <see cref="T:System.Linq.IQueryable`1"/> collection of users.
		/// </summary>
		/// <value>
		/// An <see cref="T:System.Linq.IQueryable`1"/> collection of users.
		/// </value>
		public IQueryable<TUser> Users => _config.Users.Values.AsQueryable();

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
		}

		#region Unimplemented
		/// <summary>
		/// Sets the given <paramref name="userName"/> for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose name should be set.</param>
		/// <param name="userName">The user name to set.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Sets the given normalized name for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose name should be set.</param>
		/// <param name="normalizedName">The normalized name to set.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Creates the specified <paramref name="user"/> in the user store, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user to create.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult"/> of the creation operation.
		/// </returns>
		public Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Updates the specified <paramref name="user"/> in the user store, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user to update.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult"/> of the update operation.
		/// </returns>
		public Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Deletes the specified <paramref name="user"/> from the user store, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user to delete.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult"/> of the update operation.
		/// </returns>
		public Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Sets the password hash for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose password hash to set.</param>
		/// <param name="passwordHash">The password hash to set.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
		/// </returns>
		public Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Sets the <paramref name="email"/> address for a <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email should be set.</param>
		/// <param name="email">The email to set.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task SetEmailAsync(TUser user, string email, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Sets the flag indicating whether the specified <paramref name="user"/>'s email address has been confirmed or not, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email confirmation status should be set.</param>
		/// <param name="confirmed">A flag indicating if the email address has been confirmed, true if the address is confirmed otherwise false.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Sets the normalized email for the specified <paramref name="user"/>, as an asynchronous operation.
		/// </summary>
		/// <param name="user">The user whose email address to set.</param>
		/// <param name="normalizedEmail">The normalized email to set for the specified <paramref name="user"/>.</param>
		/// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}
		#endregion
	}
}
