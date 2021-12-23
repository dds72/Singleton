
# ASP NET Core 3.1 Singleton service with queue job procesing

Postres with user 'postgres' and password 'postgres' is used.

**Singleton** singleton service with queue and worker

**Transient** transient service consumed by **Singleton** and dependent on scoped **SingletonContext**

**DataController** adds job to **Singleton** queue
