# EF Core bug?

- Create a catalog on your local database server called `BugRepro`
- Run the `CreateSchema.sql` script on it
- Open SQL Server Profiler and start a new trace on `BugRepro`
- Compile and run the project, observing the traces

# Expected Behavior
Both the EFCore and EF6 versions should produce a single database query that retrieves address labels for customer 4.

# Actual Behavior
The EFCore version produces several queries, instead of one query.

# Thoughts
This could be due to the use of `Concat`? In EF6 and below, `Concat` took an `IEnumerable<>` as its second parameter, but internall checked whether this was actually an `IQueryable<>`. Maybe this functionality was lost in EFCore?
