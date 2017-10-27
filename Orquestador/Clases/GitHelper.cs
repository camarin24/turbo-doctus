using System;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace Orquestador.Clases
{
    public class GitHelper
    {


        public void Init(string path, string origin)
        {
            Repository.Init(path);
            Remote(origin, path);
        }

        public void Remote(string origin, string path)
        {
            using (var repo = new Repository(path))
            {
                Remote remote = repo.Network.Remotes.Add("origin", origin);
                repo.Branches.Update(repo.Head,
                    b => b.Remote = remote.Name,
                    b => b.UpstreamBranch = repo.Head.CanonicalName);
            }
        }

        public void Add(string path)
        {
            using (var repo = new Repository(path))
            {
                Commands.Stage(repo, "*");
            }
        }
        public void Commit(string path)
        {
            Add(path);
            using (var repo = new Repository(path))
            {
                // Create the committer's signature and commit
                Signature author = new Signature("camarin", "cm961224@gmail.com", DateTime.Now);
                Signature committer = author;
                // Commit to the repository
                repo.Commit("Commit!!", author, committer);
            }
        }

        public void CreateBranch(string path,string branch)
        {
            using (var repo = new Repository(path))
            {
                //repo.Branches.Add(branch,"HEAD");
                repo.CreateBranch(branch);
            }
        }

        public void Checkout(string path,string branchName,bool create = true)
        {
            using (var repo = new Repository(path))
            {
                var branch = repo.Branches[branchName];

                if (branch == null)
                {
                    // not exists
                    if(create)
                        CreateBranch(path, branchName);
                }
                Commands.Checkout(repo, branchName);
            }
        }


        public void Push(string path, string branch = "Dev")
        {
            using (var repo = new Repository(path))
            {
                PushOptions options = new PushOptions();
                options.CredentialsProvider = new CredentialsHandler(
                    (url, usernameFromUrl, types) =>
                        new UsernamePasswordCredentials()
                        {
                            Username = "cm961224@gmail.com",
                            Password = "tupapitomk24"
                        });
                //repo.Branches.Update(repo.Branches[branch],
                  //  b => b.Remote = branch);

                repo.Network.Push(repo.Branches[branch], options);
            }
        }

    }
}