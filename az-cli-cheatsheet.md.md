
## Azure CLI preview - dry-run
#az #cli #dry-run

**az cli doesn't have a universal "preview" mode** because it's imperative rather than declarative. However, you can:

```powershell
# Many commands support --dry-run (but not all)
az vm delete --dry-run --ids $vmId

# Use --output table to preview what you're targeting
az resource list --resource-group myRG --output table

# For destructive operations, always list first
az group list --query "[?name=='myRG']" --output table
```

