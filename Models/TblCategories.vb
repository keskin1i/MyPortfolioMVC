﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System.Collections.Generic

Namespace MyPortfolioMVC.Models

    Public Partial Class TblCategories
        <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")>
        Public Sub New()
            TblProjects = New HashSet(Of TblProjects)()
        End Sub

        Public Property CategoryId As Integer
        Public Property Name As String

        <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")>
        Public Overridable Property TblProjects As ICollection(Of TblProjects)
    End Class
End Namespace
