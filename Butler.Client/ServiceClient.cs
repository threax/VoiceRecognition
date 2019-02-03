using Threax.AspNetCore.Halcyon.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Butler.Client {

public class RoleAssignmentsResult 
{
    private HalEndpointClient client;

    public RoleAssignmentsResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private RoleAssignments strongData = default(RoleAssignments);
    public RoleAssignments Data 
    {
        get
        {
            if(this.strongData == default(RoleAssignments))
            {
                this.strongData = this.client.GetData<RoleAssignments>();  
            }
            return this.strongData;
        }
    }

    public async Task<RoleAssignmentsResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new RoleAssignmentsResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task<RoleAssignmentsResult> Update(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class AppCommandSetResult 
{
    private HalEndpointClient client;

    public AppCommandSetResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private AppCommandSet strongData = default(AppCommandSet);
    public AppCommandSet Data 
    {
        get
        {
            if(this.strongData == default(AppCommandSet))
            {
                this.strongData = this.client.GetData<AppCommandSet>();  
            }
            return this.strongData;
        }
    }

    public async Task<AppCommandSetResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new AppCommandSetResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task Execute() 
    {
        var result = await this.client.LoadLink("Execute");
    }

    public bool CanExecute 
    {
        get 
        {
            return this.client.HasLink("Execute");
        }
    }

    public HalLink LinkForExecute 
    {
        get 
        {
            return this.client.GetLink("Execute");
        }
    }

    public async Task<AppCommandSetResult> Update(AppCommandSetInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new AppCommandSetResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class AppCommandSetCollectionResult 
{
    private HalEndpointClient client;

    public AppCommandSetCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private AppCommandSetCollection strongData = default(AppCommandSetCollection);
    public AppCommandSetCollection Data 
    {
        get
        {
            if(this.strongData == default(AppCommandSetCollection))
            {
                this.strongData = this.client.GetData<AppCommandSetCollection>();  
            }
            return this.strongData;
        }
    }

    private List<AppCommandSetResult> itemsStrong = null;
    public List<AppCommandSetResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<AppCommandSetResult>(clients.Select(i => new AppCommandSetResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<AppCommandSetCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<AppCommandSetResult> Add(AppCommandSetInput data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new AppCommandSetResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<AppCommandSetCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<AppCommandSetCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<AppCommandSetCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<AppCommandSetCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class EntryPointInjector 
{
    private string url;
    private IHttpClientFactory fetcher;
    private Task<EntryPointResult> instanceTask = default(Task<EntryPointResult>);

    public EntryPointInjector(string url, IHttpClientFactory fetcher)
    {
        this.url = url;
        this.fetcher = fetcher;
    }

    public Task<EntryPointResult> Load()
    {
        if (this.instanceTask == default(Task<EntryPointResult>))
        {
            this.instanceTask = EntryPointResult.Load(this.url, this.fetcher);
        }
        return this.instanceTask;
    }
}

public class EntryPointResult 
{
    private HalEndpointClient client;

    public static async Task<EntryPointResult> Load(string url, IHttpClientFactory fetcher)
    {
        var result = await HalEndpointClient.Load(new HalLink(url, "GET"), fetcher);
        return new EntryPointResult(result);
    }

    public EntryPointResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private EntryPoint strongData = default(EntryPoint);
    public EntryPoint Data 
    {
        get
        {
            if(this.strongData == default(EntryPoint))
            {
                this.strongData = this.client.GetData<EntryPoint>();  
            }
            return this.strongData;
        }
    }

    public async Task<AppCommandSetCollectionResult> ListAppCommandSets(AppCommandSetQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListAppCommandSets", data);
        return new AppCommandSetCollectionResult(result);

    }

    public bool CanListAppCommandSets 
    {
        get 
        {
            return this.client.HasLink("ListAppCommandSets");
        }
    }

    public HalLink LinkForListAppCommandSets 
    {
        get 
        {
            return this.client.GetLink("ListAppCommandSets");
        }
    }

    public async Task<HalEndpointDoc> GetListAppCommandSetsDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListAppCommandSets", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListAppCommandSetsDocs() {
        return this.client.HasLinkDoc("ListAppCommandSets");
    }

    public async Task<AppCommandSetResult> AddAppCommandSet(AppCommandSetInput data) 
    {
        var result = await this.client.LoadLinkWithData("AddAppCommandSet", data);
        return new AppCommandSetResult(result);

    }

    public bool CanAddAppCommandSet 
    {
        get 
        {
            return this.client.HasLink("AddAppCommandSet");
        }
    }

    public HalLink LinkForAddAppCommandSet 
    {
        get 
        {
            return this.client.GetLink("AddAppCommandSet");
        }
    }

    public async Task<HalEndpointDoc> GetAddAppCommandSetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("AddAppCommandSet", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddAppCommandSetDocs() {
        return this.client.HasLinkDoc("AddAppCommandSet");
    }

    public async Task<EntryPointResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new EntryPointResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> GetUser() 
    {
        var result = await this.client.LoadLink("GetUser");
        return new RoleAssignmentsResult(result);

    }

    public bool CanGetUser 
    {
        get 
        {
            return this.client.HasLink("GetUser");
        }
    }

    public HalLink LinkForGetUser 
    {
        get 
        {
            return this.client.GetLink("GetUser");
        }
    }

    public async Task<HalEndpointDoc> GetGetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("GetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetUserDocs() {
        return this.client.HasLinkDoc("GetUser");
    }

    public async Task<UserCollectionResult> ListUsers(RolesQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListUsers", data);
        return new UserCollectionResult(result);

    }

    public bool CanListUsers 
    {
        get 
        {
            return this.client.HasLink("ListUsers");
        }
    }

    public HalLink LinkForListUsers 
    {
        get 
        {
            return this.client.GetLink("ListUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListUsersDocs() {
        return this.client.HasLinkDoc("ListUsers");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task<UserSearchCollectionResult> ListAppUsers(UserSearchQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListAppUsers", data);
        return new UserSearchCollectionResult(result);

    }

    public bool CanListAppUsers 
    {
        get 
        {
            return this.client.HasLink("ListAppUsers");
        }
    }

    public HalLink LinkForListAppUsers 
    {
        get 
        {
            return this.client.GetLink("ListAppUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListAppUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListAppUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListAppUsersDocs() {
        return this.client.HasLinkDoc("ListAppUsers");
    }
}

public class UserCollectionResult 
{
    private HalEndpointClient client;

    public UserCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserCollection strongData = default(UserCollection);
    public UserCollection Data 
    {
        get
        {
            if(this.strongData == default(UserCollection))
            {
                this.strongData = this.client.GetData<UserCollection>();  
            }
            return this.strongData;
        }
    }

    private List<RoleAssignmentsResult> itemsStrong = null;
    public List<RoleAssignmentsResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<RoleAssignmentsResult>(clients.Select(i => new RoleAssignmentsResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<RoleAssignmentsResult> Add(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<UserCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class UserSearchResult 
{
    private HalEndpointClient client;

    public UserSearchResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearch strongData = default(UserSearch);
    public UserSearch Data 
    {
        get
        {
            if(this.strongData == default(UserSearch))
            {
                this.strongData = this.client.GetData<UserSearch>();  
            }
            return this.strongData;
        }
    }

    public async Task<UserSearchResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }
}

public class UserSearchCollectionResult 
{
    private HalEndpointClient client;

    public UserSearchCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearchCollection strongData = default(UserSearchCollection);
    public UserSearchCollection Data 
    {
        get
        {
            if(this.strongData == default(UserSearchCollection))
            {
                this.strongData = this.client.GetData<UserSearchCollection>();  
            }
            return this.strongData;
        }
    }

    private List<UserSearchResult> itemsStrong = null;
    public List<UserSearchResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<UserSearchResult>(clients.Select(i => new UserSearchResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserSearchCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<UserSearchCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserSearchCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserSearchCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserSearchCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserSearchCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserSearchCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserSearchCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserSearchCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}
}
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v9.10.49.0 (Newtonsoft.Json v11.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace Butler.Client
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class RoleAssignments 
    {
        [Newtonsoft.Json.JsonProperty("editCommands", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditCommands { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editRoles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("superAdmin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SuperAdmin { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RoleAssignments FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RoleAssignments>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public enum KeyModifier
    {
        [System.Runtime.Serialization.EnumMember(Value = "None")]
        None = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = "Ctrl")]
        Ctrl = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = "Alt")]
        Alt = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = "CtrlAlt")]
        CtrlAlt = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = "Shift")]
        Shift = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = "CtrlShift")]
        CtrlShift = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = "AltShift")]
        AltShift = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = "CtrlAltShift")]
        CtrlAltShift = 7,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommandSet 
    {
        [Newtonsoft.Json.JsonProperty("appCommandSetId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AppCommandSetId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("voicePrompt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VoicePrompt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("response", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Response { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifier", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public KeyModifier Modifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("appCommandId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AppCommandId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AppCommandSet FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AppCommandSet>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommandSetInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("voicePrompt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VoicePrompt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("response", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Response { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifier", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public KeyModifier Modifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("appCommandId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AppCommandId { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AppCommandSetInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AppCommandSetInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommandSetCollection 
    {
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>Lookup a appCommandSet by id.</summary>
        [Newtonsoft.Json.JsonProperty("appCommandSetId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? AppCommandSetId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AppCommandSetCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AppCommandSetCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class AppCommandSetQuery 
    {
        /// <summary>Lookup a appCommandSet by id.</summary>
        [Newtonsoft.Json.JsonProperty("appCommandSetId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? AppCommandSetId { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AppCommandSetQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AppCommandSetQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class EntryPoint 
    {
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static EntryPoint FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EntryPoint>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class RolesQuery 
    {
        /// <summary>The guid for the user, this is used to look up the user.</summary>
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> UserId { get; set; }
    
        /// <summary>A name for the user. Used only as a reference, will be added to the result if the user is not found.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RolesQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RolesQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserCollection 
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearchQuery 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearchCollection 
    {
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.49.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class UserSearch 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearch FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearch>(data);
        }
    
    }
}
