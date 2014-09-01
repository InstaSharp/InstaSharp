# InstaSharp

InstaSharp is a wrapper around the Instagram API.  It's goal is to provide you with a clean and neat interface for ineracting with Instagram's data services, while taking care of all the lower level things like HTTP requests, OAuth flow, and mapping the JSON request to .NET classes.

[![Build status](https://ci.appveyor.com/api/projects/status/ch334xwq15i9pcum)](https://ci.appveyor.com/project/Fujiy/instasharp)

###Where do I get support?

Bugs, Feature Requests and Discussion at [github.com/InstaSharp/InstaSharp/issues](https://github.com/InstaSharp/InstaSharp/issues) or on [Stack Overflow](http://stackoverflow.com/questions/tagged/instasharp). Feel free to submit Pull Requests on GitHub.

###Where is the current documentation?

See [Documentation](http://instasharp.github.io/InstaSharp/Documentation/index.html)

## Getting Started

### Register Your Application 
 
To get started, you will need to register an application with Instagram.  They will provide you with a client id, and a client secret.  They will additionally ask you for a callback URL. This is simply a URL that your browser will redirect back to during the Instagram Auth flow.

### The InstagramConfig Class

Now that you have registered an application, you need to create an instance of the InstagramConfig class.  This class has many of the options specified for you already, with optional overrides.

	var clientId = ConfigurationManager.AppSettings["client_id"];
	var clientSecret = ConfigurationManager.AppSettings["client_secret"];
	var redirectUri = ConfigurationManager.AppSettings["redirect_uri"];
	var realtimeUri = "";

	InstagramConfig config = new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);

### Authenticate

Use the OAuth class to authenticate. It provides a helper to give you the initial link for handing users off to Instagram for authentication.  It will want to know what level of access you are requesting via the "scope".

	@{
	    // create the auth url
	    var scopes = new List<OAuth.Scope>();
	    scopes.Add(OAuth.Scope.Likes);
	    scopes.Add(OAuth.Scope.Comments);


	    var link = OAuth.AuthLink(config.OAuthURI + "/authorize", config.ClientId, config.RedirectURI, scopes, OAuth.ResponseType.Code);
	}

Now Instagram will athenticate the user on their end and callback to your callback url.  When you receive that callback, you need to respond with your client secret.  Instagram will then respond to that request with the authorization token.

    [GET("oauth")]
    public async Task<ActionResult> Index(string code)
    {
        // add this code to the auth object
        var auth = new InstaSharp.OAuth(config);
        
        // now we have to call back to instagram and include the code they gave us
        // along with our client secret
        var oauthResponse = await auth.RequestToken(code);

        // tell the session that we are authenticated
        config.isAuthenticated = true;

        // both the client secret and the token are considered sensitive data, so we won't be
        // sending them back to the browser. we'll only store them temporarily.  If a user's session times
        // out, they will have to click on the authenticate button again - sorry bout yer luck.
        Session.Add("InstaSharp.AuthInfo", oauthResponse);

        // all done, lets redirect to the home controller which will send some intial data to the app
        return RedirectToAction("Index", "Home");
    }

Now you are authenticated and ready to call the Instagram Endpoints.  Instasharp carves these up under the "endpoints" namespace.  Each one is a class and will be expecting a configuration object and an OAuthResponse object.  For instance, you can request a user's feed as such...

	readonly InstaSharp.Endpoints.Users _users;

    public UsersController()
    {
        users = new Endpoints.Users(config, oauthResponse);
    }

    [GET("api/users/feed")]
    public async Task<ActionResult> Feed(string next_max_id)
    {
        var feed = next_max_id == null ? await users.Feed() : await users.Feed(next_max_id);

        // return plain JSON
        return Json(result.Data);
    }

Each response returned by InstaSharp will contains two objects: a Meta object, and a "Data" property that has the reponse fully mapped to .NET types.

The InstaSharp library embeds the documentation of Instagram into the code.  Each endpoint method will tell you if it requires authentication, and what parameters it needs.
