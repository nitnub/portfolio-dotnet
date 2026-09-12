


echo "Running SQL init commands..."
sqlcmd -S localhost -U sa -P 'admiTest321!' < ./setup_env/create_app_user.sql
echo "Done! Run project from Rider using PortfolioWeb:https configuration in the runner."

echo "App test username: testUser@env.com"
echo "App test password: Pass1233!"