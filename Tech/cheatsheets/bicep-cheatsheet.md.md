

## Bicep Validation
#bicep #what-if #validation


**Bicep**: Always run `az deployment group what-if` before committing

**Bicep has excellent validation options:**
```powershell
# Validate template syntax and resource definitions
az deployment group validate --resource-group myRG --template-file main.bicep

# What-if analysis (shows what would change) - THE BICEP EQUIVALENT of terraform plan
az deployment group what-if --resource-group myRG --template-file main.bicep

# Compile and validate Bicep syntax
az bicep build --file main.bicep
```

The `what-if` command is your Terraform plan equivalent - it shows exactly what resources would be created, modified, or deleted without actually making changes.