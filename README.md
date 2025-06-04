# AVA.PacxPlugins.AddSolutionComponent

Plugin **PACX**: https://github.com/neronotte/Greg.Xrm.Command

# **Installazione**

Andare nel path

C:\\Users**\\&lt;username&gt;\\**AppData\\Local\\Greg.Xrm.Command\\Plugins

E inserire la cartella **AVA.PacxPlugins.AddSolutionComponent**

# **Comando**

**addsolutioncomponent**

# **Argomenti**

| **Long Name** | **Required?** | **Description** | **Type** | **Note** |
| --- | --- | --- | --- | --- |
| componentType | Y   | The type of the component to add | string | Guardare lista valori per I component disponibili |
| componentName | Y   | The name of the component to add | string |     |
| solutionName | Y   | The name of the solution | string |     |

## **Lista valori**

### **componentType**

| **Argomento** | **Valore disponibile** | **Case sensitive** |
| --- | --- | --- |
| componentType | WebResource | Y   |

# **Esempio**

pacx addsolutioncomponent --componentType "WebResource" --componentName "egl_/scripts/egl_cessationrequest_agency/egl_cessationrequest_agency.ribbon.js" --solutionName "test-bug"

 ![image](https://github.com/user-attachments/assets/aea8964d-a9b5-4576-a6f9-b10bc97f1abc)
