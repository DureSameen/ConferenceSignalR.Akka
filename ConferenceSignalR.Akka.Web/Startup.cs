using Akka.Actor;
using ConferenceSignalR.Akka.ActorModels.Actors;
using ConferenceSignalR.Akka.ActorModels.ExternalSystems;
using ConferenceSignalR.Akka.Web.ConferenceHubs;
using ConferenceSignalR.Akka.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 

namespace ConferenceSignalR.Akka.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
            

        public IConfiguration Configuration { get; } 
      
        // This method gets called by the runtime. Use this method to add services to the container.
        public delegate ActorReferences ActorReferencesProvider();
        
        public void ConfigureServices(IServiceCollection services )
        {
            services.AddControllersWithViews();
         
            services.AddRazorPages();
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors  = true;
            });

             
            var actorSystem = ActorSystem.Create("ConferenceSystem");
            services.AddSingleton(typeof(ActorSystem), (serviceProvider) => actorSystem);
            services.AddSingleton<ConferenceActorSystem>();
            services.AddSingleton<IConferenceEventsPusher, SignalRConferenceEventsPusher>();

            services.AddSingleton<ActorReferencesProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                var conferenceControllerActor = actorSystem.ActorOf<ConferenceControllerActor>();
                var signalRConferenceEventsPusher = provider.GetService<IConferenceEventsPusher>();
                var signalRBridgeActor = actorSystem.ActorOf(Props.Create(() => new SignalRBridgeActor(signalRConferenceEventsPusher, conferenceControllerActor)));
                var references = new ActorReferences() { ConferenceController = conferenceControllerActor, SignalRBridge = signalRBridgeActor };
                return () => references; 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
           
            app.UseRouting();

            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ConferenceHub>("/conferenceHub");
                endpoints.MapRazorPages();
            });



            lifetime.ApplicationStarted.Register(() =>
            {
                app.ApplicationServices.GetService<ActorSystem>(); // start Akka.NET
            });
            lifetime.ApplicationStopping.Register(() =>
            {
                app.ApplicationServices.GetService<ActorSystem>().Terminate().Wait();
            });

        }
        
    }

   
  
}
 