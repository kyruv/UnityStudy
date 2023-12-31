# Generated by Django 5.0 on 2023-12-15 22:23

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('app', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='user',
            name='game_score',
            field=models.FloatField(blank=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='game_time',
            field=models.FloatField(blank=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='s1_q1',
            field=models.CharField(blank=True, max_length=10),
        ),
        migrations.AlterField(
            model_name='user',
            name='s1_q2',
            field=models.IntegerField(blank=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='s2_q1',
            field=models.IntegerField(blank=True),
        ),
    ]
