from django.contrib import admin
from app.models import User

class MyAdmin(admin.ModelAdmin):
    readonly_fields = ('created_at','updated_at',)

admin.site.register(User, MyAdmin)

