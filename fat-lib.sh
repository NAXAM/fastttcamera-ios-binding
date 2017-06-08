######################
# Options
######################

REVEAL_ARCHIVE_IN_FINDER=true


UNIVERSAL_LIBRARY_DIR="${BUILD_DIR}/${CONFIGURATION}-iphoneuniversal"
OUTPUT_DIR="${PROJECT_DIR}/Output/${CONFIGURATION}-iphoneuniversal/"

rm -rf "$OUTPUT_DIR"
mkdir -p "$OUTPUT_DIR"

######################
# Create directory for universal
######################

rm -rf "${UNIVERSAL_LIBRARY_DIR}"
mkdir -p "${UNIVERSAL_LIBRARY_DIR}"

######################
# Build Frameworks
######################

function build() {
    xcodebuild -project ./Pods/Pods.xcodeproj -scheme $1 -sdk iphonesimulator -configuration ${CONFIGURATION} clean build CONFIGURATION_BUILD_DIR=${BUILD_DIR}/${CONFIGURATION}-iphonesimulator 2>&1
    xcodebuild -project ./Pods/Pods.xcodeproj -scheme $1 -sdk iphoneos -configuration ${CONFIGURATION} clean build CONFIGURATION_BUILD_DIR=${BUILD_DIR}/${CONFIGURATION}-iphoneos 2>&1
    
    FRAMEWORK_NAME="$1"
    SIMULATOR_LIBRARY_PATH="${BUILD_DIR}/${CONFIGURATION}-iphonesimulator/lib${FRAMEWORK_NAME}.a"
    DEVICE_LIBRARY_PATH="${BUILD_DIR}/${CONFIGURATION}-iphoneos/lib${FRAMEWORK_NAME}.a"
    FRAMEWORK="${UNIVERSAL_LIBRARY_DIR}/lib${FRAMEWORK_NAME}.a"
    
    ######################
    # Copy files Library
    ######################
    
    cp -r "${BUILD_DIR}/${CONFIGURATION}-iphoneos/." "${UNIVERSAL_LIBRARY_DIR}/"
    
    
    ######################
    # Make an universal binary
    ######################
    
    lipo "${SIMULATOR_LIBRARY_PATH}" "${DEVICE_LIBRARY_PATH}" -create -output "${FRAMEWORK}" | echo
    
    ######################
    # On Release, copy the result to release directory
    ######################
    
    cp -r "${UNIVERSAL_LIBRARY_DIR}" "$OUTPUT_DIR"
}

frameworks=(FastttCameraFilters)
for framework in "${frameworks[@]}"
do
build $framework
done

if [ ${REVEAL_ARCHIVE_IN_FINDER} = true ]; then
open "${OUTPUT_DIR}/"
fi