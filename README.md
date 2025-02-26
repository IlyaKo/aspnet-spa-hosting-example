# ASP.NET SPA Hosting Example
This repository provides examples of two different hosting models for Single Page Applications (SPA) with ASP.NET. 
It demonstrates how to organize hosting models and simplify development with a proxy server for hot reload functionality. 
It also addresses the issue of Cross-Origin Resource Sharing (CORS).

## Structure
Both approaches preserve the instant feedback loop that developers love (thanks to Vite's hot reload), but provide different architectural options. The **ExpenseTracker** shows "real" separation for complex applications, while **TodoApp** demonstrates the flexibility of ASP.NET as a full-stack host.

### ExpenseTracker
- Separate processes for hosting backend and frontend.
- CORS configured in the backend application settings file.

### TodoApp
- ASP.NET serves frontend static files.
- Doesn't need to worry about CORS in production, solved in development by proxying queries.
