#!/bin/bash
source ./build.sh &&
  git add -A &&
  git commit -m "Rebuild dist" &&
  git checkout gh-pages &&
  git merge --no-ff -m "Merging 'master' into 'gh-pages'" master &&
  git push origin gh-pages &&
  git checkout master
