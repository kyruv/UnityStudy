# Generated by Django 5.0 on 2024-01-23 08:28

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('example_app', '0005_flappybirdstudyresult_prolific_id'),
    ]

    operations = [
        migrations.DeleteModel(
            name='User',
        ),
    ]