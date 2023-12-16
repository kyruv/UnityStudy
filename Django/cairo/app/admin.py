from django.contrib import admin
from app.models import User
from import_export.admin import ExportActionMixin

class MyAdmin(ExportActionMixin, admin.ModelAdmin):
    readonly_fields = ('created_at','updated_at',)

admin.site.register(User, MyAdmin)

