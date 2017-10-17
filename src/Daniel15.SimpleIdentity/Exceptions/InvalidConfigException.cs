using System;

namespace Daniel15.SimpleIdentity.Exceptions
{
    class InvalidConfigException : Exception
    {
	    public InvalidConfigException() :
		    base("SimpleIdentity configuration was invalid! Please ensure it is correctly configured in appsettings.json.")
	    {
	    }
    }
}
