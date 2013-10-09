# InstaSharp

InstaSharp is a wrapper around the Instagram API.  It's goal is to provide you with a clean and neat interface for ineracting with Instagram's data services, while taking care of all the lower level things like HTTP requests, OAuth flow, and mapping the JSON request to .NET classes.

## Getting Started

### Register Your Application 
 
To get started, you will need to register an application with Instagram.  They will provide you with a client id, and a client secret.  They will additionally ask you for a callback URL.  This is simply a URL that your browser will redirect back to during the Instagram Auth flow.

### The InstagramConfig Class

Now that you have registered an application, you need to create an instance of the InstagramConfig class.  This class has many of the options specified for you already, with optional overrides.  For instance, if you are using Instasharp in a web app, you would create the InstagramConfig class and then store it's instance in the session for easy retrieval on subsequent requests.

	var clientId = ConfigurationManager.AppSettings.Get("client_id");
	var clientSecret = ConfigurationManager.AppSettings.Get("client_secret");
	var redirectUri = ConfigurationManager.AppSettings.Get("redirect_uri");
	var realtimeUri = "";

	config = new InstaSharp.InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);

	context.Session.Add("InstaSharp.Config", config);

### Authenticate

Use the OAuth class to authenticate.  It provides a helper to give you the initial link for handing users off to Instagram for authentication.  It will want to know what level of access you are requesting via the "scope".

	@{
	    // create the auth url
	    var scopes = new List<OAuth.Scope>();
	    scopes.Add(OAuth.Scope.Likes);
	    scopes.Add(OAuth.Scope.Comments);


	    var link = OAuth.AuthLink(InstaSharpConfig.config.OAuthURI + "/authorize", InstaSharpConfig.config.ClientId,
	    InstaSharpConfig.config.RedirectURI, scopes, OAuth.ResponseType.Code);
	}

Now Instagram will athenticate the user on their end and callback to your callback url.  When you receive that callback, you need to respond with your client secret.  Instagram will then respond to that request with the authorization token.

	 [GET("oauth")]
    public ActionResult Index(string code)
    {
        // add this code to the auth object
        var auth = new InstaSharp.OAuth(InstaSharpConfig.config);
        
        // now we have to call back to instagram and include the code they gave us
        // along with our client secret
        var oauthResponse = auth.RequestToken(code);

        // tell the session that we are authenticated
        InstaSharpConfig.isAuthenticated = true;

        // both the client secret and the token are considered sensitive data, so we won't be
        // sending them back to the browser. we'll only store them temporarily.  If a user's session times
        // out, they will have to click on the authenticate button again - sorry bout yer luck.
        InstaSharpConfig.oauthResponse = oauthResponse.Data;
        Session.Add("InstaSharp.AuthInfo", oauthResponse);

        // all done, lets redirect to the home controller which will send some intial data to the app
        return RedirectToAction("Index", "Home");
    }

Now you are authenticated and ready to call the Instagram Endpoints.  Instasharp carves these up under the "endpoints" namespace.  Each one is a class and will be expecting a configuration object and an OAuthResponse object.  For instance, you can request a user's feed as such...

	readonly InstaSharp.Endpoints.Users _users;

    public UsersController()
    {
        _users = new Endpoints.Users(InstaSharpConfig.config, InstaSharpConfig.oauthResponse);
    }

    [GET("api/users/feed")]
    public ContentResult Feed(string next_max_id) {

        var feed = next_max_id == null ? _users.Feed() : _users.Feed(next_max_id);

        // return plain JSON
        return new ContentResult { Content = feed.Content, ContentType = "application/json" };

    }

Each response returned by InstaSharp is a "RestResponse".  It will contains two objects: a detailed RestRequest object, and a "Data" property that has the reponse fully mapped to .NET types.  You may use whichever suits your need best.

The InstaSharp library embeds the documentation of Instagram into the code.  Each endpont method will tell you if it requires authentication, and what parameters it needs.  It makes heavy use of default parameter values.  Any parameter surrounded by [] is optional and has a default value that it will use if you don't provide one.