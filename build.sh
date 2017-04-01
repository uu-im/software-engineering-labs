OUTDIR="tmp-www/software-engineering-labs"

# Clean output directory
rm -rf $OUTDIR

# Compile pug
pug src --out $OUTDIR

# Copy assets and code
cp -r src/vt15/assets $OUTDIR/vt15/assets
cp -r src/vt15/code $OUTDIR/vt15/code

cp -r src/vt16/assets $OUTDIR/vt16/assets
cp -r src/vt16/code $OUTDIR/vt16/code

cp -r src/vt17/assets $OUTDIR/vt17/assets
cp -r src/vt17/code $OUTDIR/vt17/code

# Move pages directories to simplify paths for end-user
mv -f $OUTDIR/vt15/pages/* $OUTDIR/vt15
mv -f $OUTDIR/vt16/pages/* $OUTDIR/vt16
mv -f $OUTDIR/vt17/pages/* $OUTDIR/vt17

echo "Devlopment build is now found in $OUTDIR"


# Create production build

cp -r $OUTDIR/* .

echo "Production build is now found in ."
