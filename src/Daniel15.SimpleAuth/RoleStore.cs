/*
 * Copyright (c) 2015 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the BSD-style license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Daniel15.SimpleAuth
{
	/// <summary>
	/// Role store for SimpleAuth. Currently does not do anything.
	/// </summary>
	/// <typeparam name="TRole">Type of the role model</typeparam>
    public class RoleStore<TRole> : IRoleStore<TRole> where TRole : SimpleAuthRole
    {
	    /// <summary>
	    /// Creates a new role in a store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role to create in the store.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult"/> of the asynchronous query.
	    /// </returns>
	    public Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Updates a role in a store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role to update in the store.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult"/> of the asynchronous query.
	    /// </returns>
	    public Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Deletes a role from the store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role to delete from the store.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult"/> of the asynchronous query.
	    /// </returns>
	    public Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Gets the ID for a role from the store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role whose ID should be returned.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that contains the ID of the role.
	    /// </returns>
	    public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Gets the name of a role from the store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role whose name should be returned.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that contains the name of the role.
	    /// </returns>
	    public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Sets the name of a role in the store as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role whose name should be set.</param><param name="roleName">The name of the role.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
	    /// </returns>
	    public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Get a role's normalized name as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role whose normalized name should be retrieved.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that contains the name of the role.
	    /// </returns>
	    public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Set a role's normalized name as an asynchronous operation.
	    /// </summary>
	    /// <param name="role">The role whose normalized name should be set.</param><param name="normalizedName">The normalized name to set</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// The <see cref="T:System.Threading.Tasks.Task"/> that represents the asynchronous operation.
	    /// </returns>
	    public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Finds the role who has the specified ID as an asynchronous operation.
	    /// </summary>
	    /// <param name="roleId">The role ID to look for.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that result of the look up.
	    /// </returns>
	    public Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

	    /// <summary>
	    /// Finds the role who has the specified normalized name as an asynchronous operation.
	    /// </summary>
	    /// <param name="normalizedRoleName">The normalized role name to look for.</param><param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
	    /// <returns>
	    /// A <see cref="T:System.Threading.Tasks.Task`1"/> that result of the look up.
	    /// </returns>
	    public Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
	    {
		    throw new NotImplementedException();
	    }

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
		}
	}
}
